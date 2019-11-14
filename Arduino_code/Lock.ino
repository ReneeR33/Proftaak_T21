void OpenLock(){
  if (lockState == LOCKED){
    servo.write(180);
    lockState = UNLOCKED;
  }
  endTimeServo = millis() + 500;
}

void CloseLock(){
  if (lockState == UNLOCKED){
    servo.write(0);
    lockState = LOCKED;
  }
  endTimeServo = millis() + 500;
}

void Lock(){
  if (millis() > endTimeServo) {
    servo.write(90);
  }
}
