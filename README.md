GPXSplitter
===========

Small code to split Etrex 30 gpx files

Etrex 30 is retarded in that in writes trace to just one track, not creating new one after acquirng new fiz, reset, power cycle. I don't like this behavior. There seems to be no program to do this so here it is - if it spots gap in data spanning over hour it splits trace into new track
