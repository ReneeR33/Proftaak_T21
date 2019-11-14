using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace SmartBike
{
    public partial class FormLocation : Form
    {
        public FormLocation()
        {
            InitializeComponent();
        }

        private void FormLocation_Load(object sender, EventArgs e)
        {
            double lat = 52;
            double lng = 6;

            map.DragButton = MouseButtons.Left;
            map.MapProvider = GMapProviders.GoogleMap;
            map.Position = new PointLatLng(lat, lng);
            map.MinZoom = 5;
            map.MaxZoom = 20;
            map.Zoom = 15;

            PointLatLng point = new PointLatLng(lat, lng);
            GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.red_dot);

            GMapOverlay markers = new GMapOverlay("markers");
            markers.Markers.Add(marker);
            map.Overlays.Add(markers);
        }
    }
}
