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

from Autodesk.Revit.DB import FilteredElementCollector, BuiltInCategory, BuiltInParameterGroup
from Autodesk.Revit.DB import ViewSchedule, SchedulableField, ScheduleFilter, ScheduleFilterType, Category

from platemate_engine import PlatemateEngine

pm_engine = PlatemateEngine()

doc = __revit__.ActiveUIDocument.Document
uidoc = __revit__.ActiveUIDocument

pmscedule_name = "BasePlateSchedule_platemation"

def main():
    with revit.TransactionGroup("Platemation"):
        pm_engine.add_baseplate_param()
        pm_engine.create_baseplate_schedule()


if __name__ == "__main__":
    main()