void removeFingerprint(){
  if(Message.startsWith("REMOVE_FINGERPRINT:")){
      Message.remove(0,19);
      int id = Message.toInt();
      Serial.println(id);
      if(RemoveFingerprint(id)){
        Serial.print("Deleted fingeprint with id = ");
        Serial.println(id);
       }
    }
    /*if (message == "HMMMMMMMMM") {
      mode = "OPENLOCK";
      Serial.println(mode);
      readFingerprint = true;
      //scanFingerprint = false;
      delay(500);
    }
    */
}
