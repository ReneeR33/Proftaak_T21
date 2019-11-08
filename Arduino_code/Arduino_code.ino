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

Servo servo;
SoftwareSerial mySerial(2, 3);
Adafruit_Fingerprint finger = Adafruit_Fingerprint(&mySerial);

String mode = "OPENLOCK";
int buttonPin_1 = 7;
int buttonPin_1_Value;
String Message;

bool isOpen = false;
bool readFingerprint = true;
bool scanFingerprint = false;
bool fingerprintDetected = false;
bool switchMode = false;
unsigned long endTime = 0;
unsigned long endTimeServo = 0;

int fingerID = -1;
int fingerPrintScan = FINGERPRINT_INVALIDIMAGE;
int fingerPrintScanProgress = 1;

int pinLock = 13;

void setup() {
  servo.attach(9);
  servo.write(90);
  pinMode(buttonPin_1, INPUT);
  //pinMode(buttonPin_2, INPUT);
  StartFingerprintscanner();
  Serial.begin(9600);  // test
  pinMode(13, OUTPUT);
}

void loop() {
  buttonPin_1_Value = digitalRead(buttonPin_1);
  Message = CheckMessage();
  
 if (millis() > endTime && readFingerprint == true) {

    fingerID = ReadFingerprint();
    endTime = millis() + 50;
  }

  if(Message != ""){
    Serial.println(Message);
  }
 
  if (mode == "OPENLOCK") {
    lock();
  }

  else if (mode == "ADDFINGERPRINT") {
    addFingerprint();
  }

  else if (mode == "DELETE_FINGERPRINT")
  {
    removeFingerprint();

  }


}
