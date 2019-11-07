#include <Servo.h>
#include <Adafruit_Fingerprint.h>
Servo servo;

SoftwareSerial mySerial(2, 3);
Adafruit_Fingerprint finger = Adafruit_Fingerprint(&mySerial);

String mode = "OPENLOCK";
int buttonPin_1 = 7;
int buttonPin_1_Value;
int buttonPin_2 = 12;
int buttonPin_2_Value;

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
  pinMode(buttonPin_2, INPUT);
  StartFingerprintscanner();
  Serial.begin(9600);
  pinMode(13,OUTPUT);                     // test
}

void loop() {
  buttonPin_1_Value = digitalRead(buttonPin_1);
  String message = CheckMessage();

  if(message == "LOCK_OPEN")
  {
    openLock();
  }
  else if(message == "LOCK_CLOSE")
  {
    closeLock();
  }
  
  
  if (millis() > endTime && readFingerprint == true) {

    fingerID = ReadFingerprint();
    endTime = millis() + 50;
  }

  if (scanFingerprint == true) {
    fingerPrintScan = finger.getImage();
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
