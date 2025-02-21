import spotipy
import pyodbc
from spotipy.oauth2 import SpotifyClientCredentials
import json

# Credenciales de Spotify
clientID = 'CLIENT_ID'
clientSecret = 'CLIENT_SECRET'

connection_string = (
    "Driver={SQL Server};"
    "Server=NOMBRESERVIDOR;"
    "Database=NOMBREDATABASE;"
    "Trusted_Connection=yes;"
)

connection = pyodbc.connect(connection_string)
cursor = connection.cursor()


# Configuración de las credenciales
client_credential_manager = SpotifyClientCredentials(client_id=clientID, client_secret=clientSecret)
sp = spotipy.Spotify(client_credentials_manager=client_credential_manager)

def get_track_data(track_id):
    """Obtiene datos de una pista específica."""
    track = sp.track(track_id)
    return {
        'Url_Image': track['album']['images'][0]['url'],
        'Nombre_Musica': track['name'],
        'Album_Musica': track['album']['name'],
        'Anio': track['album']['release_date'][:4],
        'Tiempo_Musica': track['duration_ms'] / 1000,  # Convertir a segundos
        'Numero_Reproducciones': track['popularity']
    }

def get_album_data(album_id):
    """Obtiene datos de un álbum específico."""
    album = sp.album(album_id)
    tracks_info = []
    for track in album['tracks']['items']:
        track_data = get_track_data(track['id'])
        tracks_info.append(track_data)
    return {
        'Album_Name': album['name'],
        'Release_Date': album['release_date'],
        'Tracks': tracks_info
    }

def get_album_info_by_id(album_id):
    """Obtiene información de un álbum usando su ID."""
    album_data = get_album_data(album_id)
    return album_data

def print_track_info(track_data):
    """Imprime la información de la pista en la consola."""
    print(f"Url_Image: {track_data['Url_Image']}")
    print(f"Nombre_Musica: {track_data['Nombre_Musica']}")
    print(f"Album_Musica: {track_data['Album_Musica']}")
    print(f"Año: {track_data['Anio']}")
    print(f"Tiempo_Musica: {track_data['Tiempo_Musica']} segundos")
    print(f"Numero_Reproducciones: {track_data['Numero_Reproducciones']}")
    print("\n")  # Añadir una línea en blanco para separar las pistas


def insert_track_data(track_data):
    """Inserta datos de una pista en la tabla Tracks."""
    insert_query = """
    INSERT INTO Cancion (Url_Image, Nombre_Musica, Album_Musica, Anio, Tiempo_Musica, Numero_Reproducciones)
    VALUES (?, ?, ?, ?, ?, ?)
    """
    cursor.execute(insert_query, (
        track_data['Url_Image'],
        track_data['Nombre_Musica'],
        track_data['Album_Musica'],
        track_data['Anio'],
        track_data['Tiempo_Musica'],
        track_data['Numero_Reproducciones']
    ))
    connection.commit()  # Asegúrate de confirmar la transacción

list = {
    '1RHKamkIrSEQAIUfsbYXvB',
    '3V2ApPxUSquOkjLQU3wmjh',
    '3RQQmkQEvNCY4prGKE6oc5',
    '3dM5WCvdXdNqLE14d16GmJ',
    '2gMs3mjUTftMtuunWWxZzM',
    '7kfPf285KnlWUTbqaB1jnI',
    '2xx0ajBaOvCKDgGCgEHNIA',
    '5KgFiUlQlU8pDFBleSkKXP',
    '4QLQzYNQG4bpWdEaCDb8tj',
    '5K79FLRUCSysQnVESLcTdb',
    '1hzJMWVA1Y9hNwSdtECbQy',
    '4C0rxFMtSmialjEWZ5bLVq',
    '22aCpij5GUIpkyuDN8woqa'
}

for lista in list:
    # Ejemplo de uso
    album_id = lista  # Cambia esto por el ID del álbum que deseas buscar
    data = get_album_info_by_id(album_id)

    # Insertar información de cada pista en la base de datos
    for track in data['Tracks']:
        insert_track_data(track)

    print("Datos de las pistas insertados en la base de datos.")