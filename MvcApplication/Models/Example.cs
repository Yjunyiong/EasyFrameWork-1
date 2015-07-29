﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Easy.MetaData;
using Easy.Models;

namespace MvcApplication.Models
{
    [DataConfigure(typeof(ExampleMetaData))]
    public class Example : EditorEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
    }

    class ExampleMetaData : DataViewMetaData<Example>
    {

        protected override void DataConfigure()
        {
            DataTable("Example");
            DataConfig(m => m.Id).AsIncreasePrimaryKey();
        }

        protected override void ViewConfigure()
        {
            ViewConfig(m => m.Id).AsHidden();
            ViewConfig(m => m.Text).AsTextBox().Required();
            ViewConfig(m => m.Value).AsMutiLineTextBox().MaxLength(200);
        }

    }
}