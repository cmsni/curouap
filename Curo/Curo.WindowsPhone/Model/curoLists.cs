    using Parse;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading.Tasks;
    using Windows.UI;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Imaging;


namespace Curo.DataModel
    {
        public class curoLists : INotifyPropertyChanged
        {
            public curoLists()
            {

            }
            public curoLists(String uniqueId, String title, String subtitle, String imagePath, String description, String content, string type)
            {
                this.UniqueId = uniqueId;
                this.Title = title;
                this.Subtitle = subtitle;
                this.Description = description;
                this.ImagePath = imagePath;
                this.Content = content;
                this.Type = type;
            }


            public curoLists(String uniqueId, String title, String subtitle, String imagePath, String description, String content, bool unread, Int32 status)
            {
                UniqueId = uniqueId;
                Title = title;
                Subtitle = subtitle;
                Description = description;
                ImagePath = imagePath;
                Content = content;
                Unread = unread;
                Status = status;
            }


            private bool _unread;

            private string _title;
            public string UniqueId { get; private set; }
            public string Title
            {
                get { return _title; }

                set
                {
                    _title = value;
                    NotifyPropertyChanged("Title");
                }
            }
            public string Subtitle { get; private set; }
            public string Description { get; private set; }
            public string ImagePath { get; private set; }
            public string Content { get; private set; }
            public int Status { get; private set; }
            public string Type { get; private set; }
            public Color MessageColour { get; private set; }

            public BitmapImage curoImage { get; private set; }

            public string ViewToUse { get; private set; }
            public bool Unread
            {
                get { return _unread; }
                set
                {
                    _unread = value;
                    NotifyPropertyChanged("Unread");
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            private void NotifyPropertyChanged(String info)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
            }

            public static async Task<curoLists> CreateFromParseObject(ParseObject parseObject)
            {
                return await Task.Run<curoLists>(() =>
                {
                    var mlist = new curoLists();

                    mlist.Title = parseObject.ObjectId;
                    if (parseObject.ContainsKey("title"))
                    {
                        mlist.Title = (string)parseObject["title"];
                    }


                    if (parseObject.ContainsKey("description"))
                    {
                        mlist.Description = (string)parseObject["description"];
                    }
                    if (parseObject.ContainsKey("image"))
                    {
                        mlist.ImagePath = (string)parseObject["image"];


               //         Image src = new Image();
                      //  mlist.curoImage = ImagePath;
                    }


                    if (parseObject.ContainsKey("unread"))


                    {

                        Color currentAccentColorHex = (Color)Application.Current.Resources["PhoneAccentColor"];

                        Boolean isUnread = (bool) parseObject["unread"];
                        if (isUnread == true)
                        {
                            mlist.MessageColour =currentAccentColorHex;
                        }
                        else
                        {
                            mlist.MessageColour = currentAccentColorHex;
                        }
                            mlist.Unread = isUnread;
                      

                    }


                    if (parseObject.ContainsKey("type"))
                    {
                        string mtype = (string)parseObject["type"];

                        if (mtype == "N")
                        {
                            mlist.Type = "Notes";
                            mlist.ViewToUse = "Notes.Xaml";
                        }
                    }
                    return mlist;
                });
            }
        }

    }