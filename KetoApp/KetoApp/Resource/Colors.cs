using System;
using Xamarin.Forms;

namespace KetoApp.Resource
{
    public class Colors : IResource
    {
        public ResourceDictionary GetResources()
        => new ResourceDictionary
        {
            {"MyAzure", Color.FromRgb(215,233,237)},
            {"MyBlue", Color.FromRgb(141,176,182)},
            {"MyDarkBlue", Color.FromRgb(41,85,133)},
            {"MyNavyBlue", Color.FromRgb(21,43,67)},
            {"MyOrange", Color.FromRgb(248,184,156)},
            {"MyYellow", Color.FromRgb(251,237,190)},
            {"MyBrick", Color.FromRgb(206,130,114)},
            {"MyGray", Color.FromRgb(123,132,145)},
            {"MyDarkGray", Color.FromRgb(72,78,87)},
            {"MyPeach", Color.FromRgb(250,194,179)},
            {"MyNude", Color.FromRgb(250,223,214)},
            {"MyGreen", Color.FromRgb(187,213,200)},
        };
    }
}
