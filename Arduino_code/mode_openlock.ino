void openLock(){
  
  if (buttonPin_1_Value == HIGH && isOpen == true) {
      servo.write(0);
      isOpen = false;
      endTimeServo = millis() + 500;
    }

    if (fingerID > 0 && isOpen == false) {
      servo.write(180);
      isOpen = true;
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
