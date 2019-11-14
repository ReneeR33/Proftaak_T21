//--FINGERPRINT--
//---------------
// BLACK - GND
// RED - 5V
// GREEN - 2
// WHITE - 3
//---------------

#include <Servo.h>
#include <Adafruit_Fingerprint.h>

#define ledPin 5
#define buttonPin 7
#define servoPin 9

enum State {
  OPEN_LOCK,
  ADD_FINGERPRINT,
};

enum LockState {
  LOCKED,
  UNLOCKED
};

enum Event {
  BUTTON_PRESSED,
  MESSAGE_RECEIVED,
  FINGER_DETECTED,
  NONE
};

Servo servo;
SoftwareSerial mySerial(2, 3);
Adafruit_Fingerprint finger = Adafruit_Fingerprint(&mySerial);

String Message;
unsigned long endTime = 0;
int fingerID = -1;

int buttonPinValue;

State state = OPEN_LOCK;
LockState lockState = LOCKED;
Event event;

void setup() {
  servo.attach(9);
  servo.write(90);
  pinMode(buttonPin, INPUT);
  pinMode(ledPin, OUTPUT);
  StartFingerprintscanner();

  Serial.begin(9600);  // test
}

void loop() {
  buttonPinValue = digitalRead(buttonPin);
  Message = CheckMessage();

  if (millis() > endTime && state == OPEN_LOCK) {

    fingerID = ReadFingerprint();
    endTime = millis() + 50;
  }
  Lock();
  if(Message != ""){
    Serial.println(Message);
  }
  if (buttonPinValue == HIGH) {
    event = BUTTON_PRESSED;
  }
  else if (Message != "") {
    event = MESSAGE_RECEIVED;
  }
  else if (fingerID > 0) {
    event = FINGER_DETECTED;
  }
  else {
    event = NONE;
  }

  switch (event) {
    case BUTTON_PRESSED:
      switch (state) {
        case OPEN_LOCK:
          CloseLock();
          break;
      }
      break;
    case MESSAGE_RECEIVED:
      if (Message == "STATE:OPEN_LOCK") {
        state = OPEN_LOCK;
      }
      else if (Message == "STATE:ADD_FINGERPRINT") {
        state = ADD_FINGERPRINT;
      }
      else if (Message.startsWith("REMOVE_FINGERPRINT:")) {
        Message.remove(0, 19);
        int id = Message.toInt();
        if(id > 0){
          RemoveFingerprint(id);
        }
      }
      break;
    case FINGER_DETECTED:
      switch (state) {
        case OPEN_LOCK:
          OpenLock();
          break;
      }
      break;
  }

  if (state == ADD_FINGERPRINT) {
    addFingerprint();
  }
}
