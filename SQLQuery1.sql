select cd.lastName from CastDetails cd join (Select cm.* from CastMembers cm join DVDDetails d on cm.DVDDetailsId=d.DVDDetailsId) x
on cd.CastDetailsId=x.CastDetailsId where cd.lastName='B'