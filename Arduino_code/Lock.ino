unsigned long endTimeServo = 0;

void OpenLock(){
  if (lockState == LOCKED){
    servo.write(180);
    lockState = UNLOCKED;
    digitalWrite(ledPin, HIGH);
    endTimeServo = millis() + 500;
  }
}

void CloseLock(){
  if (lockState == UNLOCKED){
    servo.write(0);
    lockState = LOCKED;
    digitalWrite(ledPin, LOW);
    endTimeServo = millis() + 500;
  }
}

void Lock(){
  if (millis() > endTimeServo) {
    servo.write(90);
  }
}
