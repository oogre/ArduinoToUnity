#include <CapacitiveSensor.h>
#include <OSCMessage.h>
#include <OSCBoards.h>


#ifdef BOARD_HAS_USB_SERIAL
#include <SLIPEncodedUSBSerial.h>
SLIPEncodedUSBSerial SLIPSerial( thisBoardsSerialUSB );
#else
#include <SLIPEncodedSerial.h>
 SLIPEncodedSerial SLIPSerial(Serial); // Change to Serial1 or Serial2 etc. for boards with multiple serial ports that don’t have Serial
#endif


CapacitiveSensor   cs_4_2 = CapacitiveSensor(4, 2);
CapacitiveSensor   cs_4_6 = CapacitiveSensor(4, 6);

void setup() {
  // put your setup code here, to run once:
  SLIPSerial.begin(9600);
  
}

void loop() {
  // put your main code here, to run repeatedly:
  sendMessage("/lightSensor", analogRead(A7));
  sendMessage("/capacitive/1", cs_4_2.capacitiveSensor(30));
  sendMessage("/capacitive/2", cs_4_6.capacitiveSensor(30));
  delay(33);
}

void sendMessage(char * addr, int value) {
  OSCMessage msg(addr);
  msg.add(value);

  SLIPSerial.beginPacket();  
    msg.send(SLIPSerial); // send the bytes to the SLIP stream
  SLIPSerial.endPacket(); // mark the end of the OSC Packet
  msg.empty(); // free space occupied by message

}
