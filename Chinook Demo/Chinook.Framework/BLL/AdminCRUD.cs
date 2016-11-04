using Chinook.Framework.DAL;
using Chinook.Framework.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data.Entity;
using Chinook.Framework.Entities.ViewModels;

namespace Chinook.Framework.BLL
{
    [DataObject]
    public class AdminCRUD
    {
        #region CRUD methods for Tracks
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Track> ListAllTracks()
        {
            using (var context = new ChinookContext())
            {
                return context.Tracks
                              .Include(x => x.Album)
                              .Include(x => x.MediaType)
                              .Include(x => x.Genre)
                              .ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public void AddTrack(Track info)
        {
            using (var context = new ChinookContext())
            {
                // Note: I might want to do other Business Process validation here
                context.Tracks.Add(info);
                context.SaveChanges(); // will trigger entity's Validation Attributes
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void UpdateTrack(Track info)
        {
            using (var context = new ChinookContext())
            {
                var existing = context.Entry(info);
                existing.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void DeleteTrack(Track info)
        {
            using (var context = new ChinookContext())
            {
                var existing = context.Tracks.Find(info.TrackId);
                context.Tracks.Remove(existing);
                context.SaveChanges();
            }
        }
        #endregion

        #region Foreign Key Methods
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<DropDownDataItem> ListAlbumTitles()
        {
            using (var context = new ChinookContext())
            {
                var result = from data in context.Albums
                             orderby data.Title
                             select new DropDownDataItem()
                             {
                                 DisplayText = data.Title,
                                 DataValue = data.AlbumId.ToString()
                             };
                return result.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<DropDownDataItem> ListGenres()
        {
            using (var context = new ChinookContext())
            {
                var result = from data in context.Genres
                             orderby data.Name
                             select new DropDownDataItem()
                             {
                                 DisplayText = data.Name,
                                 DataValue = data.GenreId.ToString()
                             };
                return result.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<DropDownDataItem> ListMediaTypes()
        {
            using (var context = new ChinookContext())
            {
                var result = from data in context.MediaTypes
                             orderby data.Name
                             select new DropDownDataItem()
                             {
                                 DisplayText = data.Name,
                                 DataValue = data.MediaTypeId.ToString()
                             };
                return result.ToList();
            }
        }
        #endregion
    }
}
