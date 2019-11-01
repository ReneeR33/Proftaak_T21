void lock(){
  if (buttonPin_1_Value == HIGH && isOpen == true) {      
      isOpen = false;
      closeLock();
      endTimeServo = millis() + 500;
    }
    if (fingerID > 0 && isOpen == false) {     
      isOpen = true;
      openLock();
      endTimeServo = millis() + 500;
    }
    if (millis() > endTimeServo) {
      servo.write(90);
    }

    if (buttonPin_2_Value == HIGH) {
      mode = "ADDFINGERPRINT";
      Serial.println(mode);
      readFingerprint = false;
      scanFingerprint = true;
      switchMode = true;
      delay(500);
    }
}
void openLock()
{
    //servo.write(180);
    digitalWrite(13, HIGH);       //test
}
void closeLock()
{
  //servo.write(0);
  digitalWrite(13, LOW);    //test
}
