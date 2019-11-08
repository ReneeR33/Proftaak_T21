bool messageWrite = false;
String message = "";

String CheckMessage()
{
  String messageDone = "";
  while (Serial.available() > 0)
  {
    char incomingByte = Serial.read();
    if (incomingByte == '#')
    {
      messageWrite = true;
      incomingByte = "";
    }
    else if (incomingByte == '%')
    {
      messageDone = message;
      message = "";
      messageWrite = false;
      break;
    }
    else if (messageWrite == true)
    {
      message = message + incomingByte;
    }
  }
  return messageDone;
}
