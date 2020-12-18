# Karpiński Maciej, 39446
# Biblioteki
import tensorflow as tf
from tensorflow import keras
import numpy as np
import matplotlib.pyplot as plt

# Przygotowanie danych do przetwarzania, rozdzielenie na dane testowe i treningowe 
(obrazki_trenujace, etykiety_trenujace), (obrazki_testowe, etykiety_testowe) = tf.keras.datasets.fashion_mnist.load_data()

# Skalowanie wartości aby były pomiędzy 0 a 1
obrazki_trenujace = obrazki_trenujace / 255.0
obrazki_testowe = obrazki_testowe / 255.0

# Model sieci neuronowej, kofiguracja
model = keras.Sequential([
    keras.layers.Flatten(input_shape=(28, 28)),  # Warstwa 1, wejściowa
    keras.layers.Dense(261, activation='relu'),  # Warstwa 2, ukryta
    keras.layers.Dense(87, activation='relu'),   # Warstwa 3, ukryta
    keras.layers.Dense(10, activation='softmax') # Warstwa 4, wyjściowa
])

# Model sieci neuronowej, kompilacja
model.compile(optimizer='adam',
              loss='sparse_categorical_crossentropy',
              metrics=['accuracy'])
# Uczenie
model.fit(obrazki_trenujace, etykiety_trenujace, epochs=15)

# Spradzenie dokładności modelu na obrazkach testowych
utrata_dokladnosci, dokladnosc = model.evaluate(obrazki_testowe,  etykiety_testowe, verbose=1) 
print('Dokładność:', dokladnosc)

# Wyświetlenie wyniku
KOLOR = 'white'
plt.rcParams['text.color'] = KOLOR
plt.rcParams['axes.labelcolor'] = KOLOR

def predict(model, obrazek, etykieta):
  klasy = ['Koszulka', 'Spodnie', 'Bluza', 'Sukienka', 'Płaszcz',
               'Sandał', 'Koszula', 'Adidasy', 'Torebka', 'Buty do kostki']
  przewidywanie = model.predict(np.array([obrazek]))
  przewidywana_klasa = klasy[np.argmax(przewidywanie)]

  show_image(obrazek, klasy[etykieta], przewidywana_klasa)


def show_image(obrazek, etykieta, rozp):
  plt.imshow(obrazek, cmap=plt.cm.binary)
  print("Spodziewane: " + etykieta)
  print("Odgadnięte: " + rozp)
  plt.title("Spodziewane: " + etykieta)
  plt.xlabel("Odgadnięte: " + rozp)
  plt.colorbar()
  plt.show()


def get_number():
  while True:
    num = input("Wpisz numer obrazka testowego(1 - 1000): ")
    if num.isdigit():
      num = int(num)
      if 0 <= num <= 1000:
        return int(num)
    else:
      print("Spróbuj ponownie...")

num = get_number()
obrazek = obrazki_testowe[num]
etykieta = etykiety_testowe[num]
predict(model, obrazek, etykieta)
