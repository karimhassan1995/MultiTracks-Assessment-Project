﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Linq;

public partial class MultiTracksDBEntities1 : DbContext
{
    public MultiTracksDBEntities1()
        : base("name=MultiTracksDBEntities1")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }

    public virtual DbSet<C__RefactorLog> C__RefactorLog { get; set; }
    public virtual DbSet<Album> Albums { get; set; }
    public virtual DbSet<Artist> Artists { get; set; }
    public virtual DbSet<AssessmentStep> AssessmentSteps { get; set; }
    public virtual DbSet<Song> Songs { get; set; }

    public virtual ObjectResult<GetAlbumDetails_Result> GetAlbumDetails()
    {
        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAlbumDetails_Result>("GetAlbumDetails");
    }

    public virtual ObjectResult<GetArtistDetails_Result> GetArtistDetails()
    {
        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetArtistDetails_Result>("GetArtistDetails");
    }

    public virtual ObjectResult<string> GetAssessmentSteps(Nullable<int> stepID)
    {
        var stepIDParameter = stepID.HasValue ?
            new ObjectParameter("stepID", stepID) :
            new ObjectParameter("stepID", typeof(int));

        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetAssessmentSteps", stepIDParameter);
    }

    public virtual ObjectResult<GetSongDetails_Result> GetSongDetails()
    {
        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetSongDetails_Result>("GetSongDetails");
    }
}
