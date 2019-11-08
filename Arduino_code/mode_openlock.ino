void lock() {
 
  if ((Message == "CLOSE_LOCK" || buttonPin_1_Value == HIGH) && isOpen == true) {
    isOpen = false;
    closeLock();
    endTimeServo = millis() + 500;
  }
  if ((fingerID > 0 || Message == "OPEN_LOCK") && isOpen == false) {
    isOpen = true;
    openLock();
    endTimeServo = millis() + 500;
  }
  if (millis() > endTimeServo) {
    servo.write(90);
  }

  if (Message == "NEXT") {
    mode = "ADDFINGERPRINT";
    Serial.println(mode);
    readFingerprint = false;
    //scanFingerprint = true;
    switchMode = true;
    delay(500);
  }
}

void openLock()
{
  servo.write(180);
}
void closeLock()
{
  servo.write(0);
}
