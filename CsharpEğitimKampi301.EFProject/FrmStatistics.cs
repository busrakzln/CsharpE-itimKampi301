﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsharpEğitimKampi301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        EğitimKampiEfTravelDbEntities db=new EğitimKampiEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            
            lblLocationCount.Text = db.Location.Count().ToString();
            lblSumCapacity.Text=db.Location.Sum(x=>x.Capacity).ToString();
            lblGuideCount.Text=db.Guide.Count().ToString();
            lblAvgCapacity.Text=db.Location.Average(x=>x.Capacity).ToString();
            lblAvgLocationPrice.Text = $"{db.Location.Average(x => x.Price):F2} TL";

            int lastCountryId=db.Location.Max(x=>x.LocationId);
            lblLastCountry.Text=db.Location.Where(x=>x.LocationId==lastCountryId).Select(
                y=>y.Country).FirstOrDefault();

            lblCapadociaLocationcapacity.Text=db.Location.Where(x=>x.City=="Kapadokya").Select(
                y=>y.Capacity).FirstOrDefault().ToString();

            lblTurkiyeCapacityAvg.Text = db.Location.Where(x=>x.Country=="Türkiye").Average(y => y.Capacity).ToString();

            var romeGuideID = db.Location.Where(x => x.City == "Roma").Select(y => y.GuideId).FirstOrDefault();
            lblRomeGuideName.Text = db.Guide.Where(x=>x.GuideId==romeGuideID).Select(y=>y.GuideName+" "+y.GuideSurname).FirstOrDefault().ToString();

            var maxCapacity=db.Location.Max(x=>x.Capacity);
            lblMaxCapacityLocation.Text=db.Location.Where(x=>x.Capacity==maxCapacity).Select(y=>y.City).FirstOrDefault().ToString();

            var maxPrice = db.Location.Max(x => x.Price);
            lblMaxPriceLocation.Text=db.Location.Where(x=>x.Price==maxPrice).Select(y=>y.City).FirstOrDefault().ToString(); 

            var guideIdByNameEnesKartal=db.Guide.Where(x=>x.GuideName=="Enes" &&x.GuideSurname=="Kartal").Select(
                y=>y.GuideId).FirstOrDefault();
            lblEnesKartalLocationCount.Text = db.Location.Where(x => x.GuideId == guideIdByNameEnesKartal).Count().ToString();

        }

       
    }
}
