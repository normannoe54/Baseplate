"""
Platemation

Creationg a schedule for Column Plate
"""

# pyRevit metadata variables
__title__ = "Platemation"
__author__ = "Yushi Kato"
__version__ = "0.1.0"

import sys
import os
from pyrevit import revit

from Autodesk.Revit.DB import FilteredElementCollector, BuiltInCategory
from Autodesk.Revit.DB import ViewSchedule, SchedulableField, ScheduleFilter, ScheduleFilterType, Category

from platemate_engine import PlatemateEngine

pm_engine = PlatemateEngine()

field_name = ("Family", "Type", "Level", "Comments", "Image")
filter_param = "Mark"

doc = __revit__.ActiveUIDocument.Document
uidoc = __revit__.ActiveUIDocument

pmscedule_name = "BasePlateSchedule_platemation"

def main():

    with revit.TransactionGroup("Platemation"):
        if not pm_engine.has_pmschedule():
            category = Category.GetCategory(doc, BuiltInCategory.OST_GenericModel)
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
                        elif el.GetName(doc) == filter_param:
                            filter_elem = platemation_schedule.Definition.AddField(el)
                    except:
                        pass
                #Add Filter to show only baseplate
                platemation_schedule_filter = platemation_schedule.Definition.GetFilterCount()
                if (platemation_schedule_filter != 0):
                    for i in range(platemation_schedule_filter):
                        for pm_filter in platemation_schedule.Definition.GetFilter(i):
                            if pm_filter.Name == pmscedule_name:
                                break
                pm_filter = ScheduleFilter(filter_elem.FieldId, ScheduleFilterType.Equal, "Water Glass")
                platemation_schedule.Definition.AddFilter(pm_filter)


if __name__ == "__main__":
    main()