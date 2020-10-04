﻿using System;
using Plugin.FilePicker;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ClassAid.DataContex;
using Firebase.Storage;
using System.Collections.ObjectModel;
using ClassAid.Models.Schedule;
using System.Diagnostics;
using ClassAid.Models.Users;

namespace ClassAid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SVG_Tester : ContentPage
    {
        public SVG_Tester()
        {
            InitializeComponent();
            
            ObservableCollection<ScheduleModel> coll;
            coll = new ObservableCollection<ScheduleModel>();
            Connection(coll);
            ScheduleList.ItemsSource = coll;
        }

        private async static void Connection(ObservableCollection<ScheduleModel> coll)
        {
            Shared shared = await FirebaseHandler.GetAdmin("AHPUEQOYDI");
            Debug.WriteLine(shared.Name);
            await FirebaseHandler.RealTimeConnection(
                    CollectionTables.ScheduleList, coll, shared.Key);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var file = await CrossFilePicker.Current.PickFile();

            if (file != null)
            {
                //string url = await FirebaseStorageHandler.SaveFile(file.GetStream());
                string url = await new FirebaseStorage("gs://classaidapp.appspot.com")
                .Child("data")
                .PutAsync(file.GetStream());
                //lbl.Text = url;
            }

            //var result = await FilePicker.PickAsync();
            //if (result != null)
            //{
            //    Text = $"File Name: {result.FileName}";
            //    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
            //        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
            //    {
            //        var stream = await result.OpenReadAsync();
            //        Image = ImageSource.FromStream(() => stream);
            //    }
            //}
        }

        private async void AddScheduleBtn_Clicked(object sender, EventArgs e)
        {
            ScheduleModel schedule = new ScheduleModel()
            {
                CourseCode = courseCode.Text,
                Subject = subjectName.Text
            };
            var data = FirebaseHandler.GetAdmin("AHPUEQOYDI");
            await FirebaseHandler.UpdateShit(schedule, data.Result.Key);
        }
    }
}