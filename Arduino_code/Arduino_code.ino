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


void setup() {
  servo.attach(9);
  servo.write(90);
  pinMode(buttonPin_1, INPUT);
  StartFingerprintscanner();
  Serial.begin(9600);
}

void loop() {
  buttonPin_1_Value = digitalRead(buttonPin_1);
  buttonPin_2_Value = digitalRead(buttonPin_2);


  if (millis() > endTime && readFingerprint == true) {

    fingerID = ReadFingerprint();
    endTime = millis() + 50;
  }

  if (scanFingerprint == true) {
    fingerPrintScan = finger.getImage();
  }


  //MODE: OPENLOCK

  if (mode == "OPENLOCK") {

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

  //MODE: ADDFINGERPRINT

  else if (mode == "ADDFINGERPRINT") {
    if (fingerPrintScan == FINGERPRINT_OK && fingerPrintScanProgress < 3) {
      fingerPrintScan = finger.image2Tz(fingerPrintScanProgress);
      if (fingerPrintScan == FINGERPRINT_OK) {
        fingerPrintScanProgress++;
        Serial.println("OK");
        Serial.println(fingerPrintScanProgress);
        delay(500);
      }
    }
    if (fingerPrintScanProgress == 3) {
      Serial.println("2 Images taken");
      fingerPrintScan = finger.createModel();
      if (fingerPrintScan == FINGERPRINT_OK) {
        Serial.println("Created a model");
        // HIER
        int id = GetFirstFreeSpace();
        //
        if (id != -1) {
          fingerPrintScan = finger.storeModel(id);
          if (fingerPrintScan == FINGERPRINT_OK) {
            Serial.print("Stored, id value = ");
            Serial.println(id);
          }
        }
        else{
          Serial.println("Scanner is full");
        }

      }
      fingerPrintScanProgress = 1;
    }
    if (buttonPin_2_Value == HIGH) {
      mode = "OPENLOCK";
      Serial.println(mode);
      readFingerprint = true;
      scanFingerprint = false;
      delay(500);
    }
  }


}
