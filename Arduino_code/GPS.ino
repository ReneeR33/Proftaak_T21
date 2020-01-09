double locationOld[2] = {1, 1};
double locationNew[2] = {0, 0};

bool LocationIsChanged()
{
  locationNew[0] = gps.location.lat();
  locationNew[1] = gps.location.lng();
  if(locationOld[0] == locationNew[0] && locationOld[1] == locationNew[1])
  {
    return false;
  }
  else
  {
    locationOld[0] = locationNew[0];
    locationOld[1] = locationNew[1];
    return true;    
  }
}

double GetLatitude()
{
  locationNew[0] = gps.location.lat();
  return locationNew[0];
}
double GetLongitude()
{
  locationNew[1] = gps.location.lng();
  return locationNew[1];
}
