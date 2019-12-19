//--FINGERPRINT--
//---------------
// BLACK - GND
// RED - 5V
// GREEN - 2
// WHITE - 3
//---------------

#include <Keypad.h>
#include <Servo.h>
#include <Adafruit_Fingerprint.h>

#define ledPin 10
#define buttonPin 12
#define servoPin 11

const byte ROWS = 4; //four rows
const byte COLS = 4; //four columns

//keypad
char hexaKeys[ROWS][COLS] = {
  {'1', '2', '3', 'A'},
  {'4', '5', '6', 'B'},
  {'7', '8', '9', 'C'},
  {'*', '0', '#', 'D'}
};
byte rowPins[ROWS] = {9, 8, 7, 6}; 
byte colPins[COLS] = {5, 4, 3, 2}; 

Keypad customKeypad = Keypad( makeKeymap(hexaKeys), rowPins, colPins, ROWS, COLS); 
//////////////////////////////////////////////////////////////////////////////

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
//SoftwareSerial mySerial(2, 3);
//Adafruit_Fingerprint finger = Adafruit_Fingerprint(&mySerial);

String Message;
unsigned long endTime = 0;
int fingerID = -1;

int buttonPinValue;

State state =  OPEN_LOCK; //OPEN_LOCK
LockState lockState = LOCKED;
Event event;

void setup() {
  servo.attach(servoPin);
  servo.write(90);
  pinMode(buttonPin, INPUT);
  pinMode(ledPin, OUTPUT);
  StartFingerprintscanner();

  Serial.begin(9600);  // test
}

void loop() {
  buttonPinValue = digitalRead(buttonPin);
  Message = CheckMessage();

  if(state != ADD_FINGERPRINT) {
    fingerID = ReadFingerprintK();
  }
  /*if (millis() > endTime && state == OPEN_LOCK) {

    fingerID = ReadFingerprint();
    endTime = millis() + 50;
  }
  */
  
  //Lock();
  if (Message != "") {
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
          //Serial.print("#ADDED_FINGERPRINT:5%");
          delay(200);
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
        Serial.println("switched");
        Serial.print("#ADD_FINGERPRINT%");
      }
      else if (Message.startsWith("REMOVE_FINGERPRINT:")) {
        Message.remove(0, 19);
        int id = Message.toInt();
        if (id > 0) {
          RemoveFingerprintK(id);
        }
      }
      else if (Message == "OPEN_LOCK" || Message == "CLOSE_LOCK"){
        OpenLock();
      }
      else if (Message == "HALLO") {
        Serial.print("#HALLO_APP%");
      }
      else if (Message == "GET_LOCKSTATE"){
        Serial.print("#LOCKSTATE:");
        Serial.print(lockState);
        Serial.print("%");
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
    addFingerprintK();
  }
}
