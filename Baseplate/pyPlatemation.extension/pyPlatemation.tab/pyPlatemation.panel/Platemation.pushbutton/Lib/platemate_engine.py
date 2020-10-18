import sys
import os
import json
from functools import wraps
from pyrevit import revit

from Autodesk.Revit.DB import FilteredElementCollector, BuiltInCategory, BuiltInParameterGroup
from Autodesk.Revit.DB import ViewSchedule, SchedulableField, ScheduleFilter, ScheduleFilterType, Category
from Autodesk.Revit import ApplicationServices
from rpw import db

doc = __revit__.ActiveUIDocument.Document
uidoc = __revit__.ActiveUIDocument

pm_schedule_name = "BasePlateSchedule_platemation"
field_name = ("Family", "Type", "Level", 'Baseplate-Type', 'Baseplate-Width', 'Baseplate-Height', 'Baseplate-Thickness')

class PlatemateEngine(object):
    def has_pmschedule(self):
        view_schedules =( FilteredElementCollector(doc)
                    .OfClass(ViewSchedule)
                    .WhereElementIsNotElementType()).ToElements()
        for vs in view_schedules:
            if pm_schedule_name in vs.Name:
                return (vs)
        return (False)

    def add_baseplate_param(self):
        cd = os.getcwd()
        temp_paramfile = os.path.join(cd, "../Lib/PM_SharedParameters.txt")
        scolumn_category = Category.GetCategory(doc, BuiltInCategory.OST_StructuralColumns)
        cat_set = __revit__.Application.Create.NewCategorySet()
        cat_set.Insert(scolumn_category)
        instancebiding = __revit__.Application.Create.NewInstanceBinding(cat_set)
        biding_map = doc.ParameterBindings

        param_file = uidoc.Application.Application.OpenSharedParameterFile()
        def_groups = param_file.Groups
        for def_group in def_groups:
            if 'column' in def_group.Name.lower():
                column_def = def_group
            for param in column_def.Definitions:
                if 'baseplate-type' in param.Name.lower():
                    bp_type_param = param
                elif 'baseplate-width' in param.Name.lower():
                    bp_width_param = param
                elif 'baseplate-height' in param.Name.lower():
                    bp_height_param = param
                elif 'baseplate-thickness' in param.Name.lower():
                    bp_thickness_param = param
        param_list = [bp_type_param, bp_width_param, bp_height_param, bp_thickness_param]

        with revit.Transaction("Add Column Param"):
            for param in param_list:
                try:
                    biding_map.Insert(param, instancebiding, BuiltInParameterGroup.PG_IDENTITY_DATA)
                except:
                    print(param.Definition.Name)
    def create_baseplate_schedule(self):
        platemation_schedule = self.has_pmschedule()
        if not platemation_schedule:
            category = Category.GetCategory(doc, BuiltInCategory.OST_StructuralColumns)
            with revit.Transaction("Create Views"):
                # Create ViewSchedule
                platemation_schedule = ViewSchedule.CreateSchedule(
                    doc,
                    category.Id, # Insert Baseplate Model CategoryId
                )
                platemation_schedule.Name = "BasePlateSchedule_platemation"

                #Add Field to show in schedule
                platemation_schedule_fields = platemation_schedule.Definition.GetSchedulableFields()
                for el in platemation_schedule_fields:
                    try:
                        if el.GetName(doc) in field_name:
                            platemation_schedule.Definition.AddField(el)
                    except Exception as e:
                        print(e)
                #Add Filter to show only baseplate
                """
                platemation_schedule_filter = platemation_schedule.Definition.GetFilterCount()
                if (platemation_schedule_filter != 0):
                    for i in range(platemation_schedule_filter):
                        for pm_filter in platemation_schedule.Definition.GetFilter(i):
                            if pm_filter.Name == pmscedule_name:
                                break
                pm_filter = ScheduleFilter(filter_elem.FieldId, ScheduleFilterType.Equal, "Water Glass")
                platemation_schedule.Definition.AddFilter(pm_filter)
                """

    def set_value(self):
        scolumn_els = (FilteredElementCollector(doc)
        .OfCategory(BuiltInCategory.OST_StructuralColumns)
        .WhereElementIsNotElementType()
        .ToElements())
        with revit.Transaction("set value"):
            for scolumn_el in scolumn_els:
                db.Element(scolumn_el).parameters['Baseplate-Type'].value = 'A4'
                db.Element(scolumn_el).parameters['Baseplate-Width'].value = 0.15
                db.Element(scolumn_el).parameters['Baseplate-Height'].value = 0.15
                db.Element(scolumn_el).parameters['Baseplate-Thickness'].value = 0.05