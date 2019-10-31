void removeFingerprint(){
  if(message.startsWith("DELETE:")){
      message.remove(0,7);
      int id = message.toInt();
      if(RemoveFingerprint(id)){
        Serial.print("Deleted fingeprint with id = ");
        Serial.println(id);
       }
    }
    if (buttonPin_2_Value == HIGH) {
      mode = "OPENLOCK";
      Serial.println(mode);
      readFingerprint = true;
      scanFingerprint = false;
      delay(500);
    }
}
