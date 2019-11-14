//--FINGERPRINT--
//---------------
// BLACK - GND
// RED - 5V
// GREEN - 2
// WHITE - 3
//---------------

#include <Servo.h>
#include <Adafruit_Fingerprint.h>

#define buttonPin 7
#define servoPin 9

enum State {
  OPEN_LOCK,
  ADD_FINGERPRINT,
  REMOVE_FINGERPRINT
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

int buttonPinValue;
String Message;

State state = OPEN_LOCK;
LockState lockState = LOCKED;
Event event;
//bool readFingerprint = true;
//bool scanFingerprint = false;
bool fingerprintDetected = false;
bool switchMode = false;
unsigned long endTime = 0;
unsigned long endTimeServo = 0;

int fingerID = -1;
int fingerPrintScan = FINGERPRINT_INVALIDIMAGE;
int fingerPrintScanProgress = 1;

//int pinLock = 13;

void setup() {
  servo.attach(9);
  servo.write(90);
  pinMode(buttonPin, INPUT);
  pinMode(13, OUTPUT);
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

  else if (state == REMOVE_FINGERPRINT) {
    removeFingerprint();
  }

  if (Message.startsWith("REMOVE_FINGERPRINT:"))
  {
    removeFingerprint();

  }
}
