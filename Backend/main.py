import cv2
from cvzone.HandTrackingModule import HandDetector
import socket

width, height = 1280, 720

# Webcam Config
capture = cv2.VideoCapture(0)
capture.set(3, width)
capture.set(4, height)

# Hand Detector
detector = HandDetector(maxHands=1, detectionCon=0.8)

# Communication Config
socketConn = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
serverAddress = ("127.0.0.1", 5052)

while True:
    # Get the frame
    sucess, img = capture.read()

    # Hands data
    hands, img = detector.findHands(img)

    data = []

    if hands:
        hand = hands[0]

        landmarksList = hand['lmList']
        # print(landmarksList)

        for landmark in landmarksList:
            data.extend([width - landmark[0], height - landmark[1], landmark[2]])

        # print(data)

        socketConn.sendto(str.encode(str(data)), serverAddress)

    img = cv2.resize(img, (0, 0), None, 0.5, 0.5)
    cv2.imshow("Image", img)
    cv2.waitKey(1)