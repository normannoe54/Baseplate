import sys
import os
from functools import wraps
from collections import namedtuple
from pyrevit import revit

from Autodesk.Revit.UI import TaskDialog
from Autodesk.Revit.DB import FilteredElementCollector, BuiltInCategory
from Autodesk.Revit.DB import ViewSchedule, ElementId

doc = __revit__.ActiveUIDocument.Document
uidoc = __revit__.ActiveUIDocument

pm_schedule_name = "BasePlateSchedule_platemation"

class PlatemateEngine(object):
    def has_pmschedule(self):
        view_schedules =( FilteredElementCollector(doc)
                    .OfClass(ViewSchedule)
                    .WhereElementIsNotElementType()).ToElements()
        for vs in view_schedules:
            if pm_schedule_name in vs.Name:
                return (True)
        return (False)