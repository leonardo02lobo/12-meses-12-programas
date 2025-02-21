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

def ObtenerArtista(id,pais,correo,contrasenia,id_usuario):
    # ID del artista (por ejemplo, el ID de Blackpink)
    artist_id = id

    # Obtener información del artista
    artist_info = sp.artist(artist_id)
    monthly_listeners = sp.artist_top_tracks(artist_id)['tracks'][0]['popularity']

    # Imprimir información relevante
    print(f"Nombre: {artist_info['name']}")
    print(f"Géneros: {', '.join(artist_info['genres'])}")
    print(f"Seguidores: {artist_info['followers']['total']}")
    print(f"Popularidad: {artist_info['popularity']}")
    print(f"Descripción: {artist_info['genres']}")
    print(f"Url: {artist_info['images'][0]['url']}")
    print(f"Oyentes mensuales (aproximado): {monthly_listeners}")
    InsertarDatos(id_usuario,artist_info['name'],correo,contrasenia,pais,', '.join(artist_info['genres']),artist_info['followers']['total'],artist_info['popularity'],artist_info['genres'],
    artist_info['images'][0]['url'],monthly_listeners)

def InsertarDatos(id_usuario,nombre,correo,contrasenia,pais,genero,seguidores,popularidad,Descripcion,url,oyentesMensuales):
    try:        # Insertar en la tabla Usuarios
        insert_query1 = """
            INSERT INTO Clon_Spotify.dbo.Usuarios (nombre_Usuario, Correo, Contrasenia, Seguidores, Seguidos, Verificacion, foto_Perfil, foto_Fondo, pais)
            VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?);
        """
        cursor.execute(insert_query1, (
        nombre,
        correo,
        contrasenia,
        int(seguidores),
        int(popularidad),
        1,
        url,
        '',
        pais
        ))
        connection.commit()

        # Insertar en la tabla Artista
        insert_query2 = """
            INSERT INTO Clon_Spotify.dbo.Artista (Oyentes_Mensuales, Descripcion, Genero, Id_Usuario)
            VALUES (?, ?, ?, ?);
        """
        cursor.execute("SET IDENTITY_INSERT Clon_Spotify.dbo.Artista ON;")
        cursor.execute(insert_query2, (
        oyentesMensuales,
        ",".join(Descripcion),
        genero,
        id_usuario
        ))
        connection.commit()
        cursor.execute("SET IDENTITY_INSERT Clon_Spotify.dbo.Artista OFF;")

        # Insertar en la tabla Premium
        insert_query3 = """
            INSERT INTO Clon_Spotify.dbo.Premium (Id_Premium, Tipo_Plan)
            VALUES (?, ?);
        """
        cursor.execute("SET IDENTITY_INSERT Clon_Spotify.dbo.Premium ON;")
        cursor.execute(insert_query3, (
        id_usuario,
        'Familiar'
        ))
        connection.commit()
        cursor.execute("SET IDENTITY_INSERT Clon_Spotify.dbo.Premium OFF;")

        print("Datos insertados correctamente.")
    except Exception as e:
        # Revertir la transacción en caso de error
        print(f"Error: {e}")

listPais = [
    'España',
    'Rusa',
    'España',
    'España',
    'España',
    'España',
    'España',
    'España',
    'Estados Unidos',
    'Puerto Rico',
    'Puerto Rico',
    'Pamana',
    'Puerto Rico',
    'Puerto Rico',
    'Puerto Rico',
    'Puerto Rico',
    'Colombia',
    'Puerto Rico',
    'Puerto Rico',
    'Puerto Rico',
    'Puerto Rico',
    'Puerto Rico',
    'Italia',
    'Puerto Rico',
    'Estados Unidos',
    'Estados Unidos',
    'Mexico',
    'Italia',
    'Colombia',
    'Británica',
    'Canadá',
    'Puerto Rico',
    'Colombia',
    'Sin Nacionalidad',
    'Puerto Rico',
    'Puerto Rico',
    'Puerto Rico',
    'Puerto Rico',
    'Puerto Rico',
    'Puerto Rico',
    'Puerto Rico',
    'Puerto Rico',
    'Puerto Rico',
    'Puerto Rico',
    'Puerto Rico',
    'Puerto Rico',
    'Puerto Rico',
    'Puerto Rico',
    'Puerto Rico',
    'Puerto Rico',
    'Colombia',
    'Puerto Rico',
    'Estados Unidos',
    'Puerto Rico',
    'Puerto Rico',
    'Argentina',
    'Puerto Rico',
    'Estados Unidos',
    'Puerto Rico',
    'España',
    'España',
    'España',
    'España',
    'España',
    'España',
    'Mexico',
    'Puerto Rico',
    'Puerto Rico',
    'Puerto Rico',
    'Puerto Rico',
    'Puerto Rico',
    'Puerto Rico',
    'España',
    'España',
    'España',
    'Estados Unidos',
]
listCorreos = [
    'KiddKeoInTheMouse@gmail.com',
    'EnryK@gmail.com',
    'YayMusic@gmail.com',
    'Quevedo@gmail.com',
    'Aitana@gmail.com',
    'SinNombre@gmail.com',
    'YungBeef@gmail.com',
    'LaPantera@gmail.com',
    'Pitbull@gamil,com',
    'RelsB@gmail.com',
    'DeLaRose@gmail.com',
    'DeLaGetto@gmail.com',
    'Sech@gmail.com',
    'BadBunny@gmail.com',
    'ChenchoCorleone@gmail.com',
    'JHAYCO@gmail.com',
    'RauwAlejandro@gmail.com',
    'BombaEstereo@gmail.com',
    'TheMarias@gamil.com',
    'Buscabulla@gmail.com',
    'Tainy@gmail.com',
    'MykeTowers@gmail.com',
    'Farruko@gmail.com',
    'DarkPoloGang@gmail.com',
    'KikoElCrazy@gmail.com',
    'KingShooter@gmail.com',
    'YoungMA@gmail.com',
    'Aleman@gmail.com',
    'sickLuke@gmail.com',
    'YungSarria@gmail.com',
    'BladeBrown@gmail.com',
    'Poundz@gmail.com',
    'AlvaroDiaz@gmail.com',
    'Feid@gmail.com',
    'SanSera@gmail.com',
    'YoungCister@gmail.com',
    'Nsqk@gmail.com',
    'paopao@gmail.com',
    'Mora@gmail.com',
    'ARON@gmail.com',
    'EladioCarrion@gmail.com',
    'Dalex@gmail.com',
    'Arcangel@gmail.com',
    'Lyanno@gmail.com',
    'Brray@gmail.com',
    'Brytiago@gmail.com',
    'MikyWoodz@gmail.com',
    'Zion&Lennox@gmail.com',
    'Wisin&Yandel@gmail.com',
    'Amenazzy@gmail.com'
    'Lunay@gmail.com',
    'JBalvin@gmail.com',
    'ÑengoFlow@gmail.com',
    'Smokepurpp@gmail.com',
    'JonZ@gmail.com',
    'Noriel@gmail.com',
    'Cazzu@gmail.com',
    'Cosculluela@gmail.com',
    'LilMosey@gmail.com',
    'Zion@gmail.com',
    'BandoBoyz@gmail.com',
    'Neelo@gmail.com',
    'REYPHARAOH@gmail.com',
    'SwaggGlock@gmail.com',
    'Elegvngster@gmail.com',
    'RenzoGoRellah@gmail.com',
    'NdKoni@gmail.com',
    'RaiNao@gmail.com',
    'Chuwi@gmail.com',
    'OmarCourtz@gmail.com',
    'DeiV@gmail.com',
    'LosPlenerosDeLaCresta@gmail.com',
    'ElPatron970@gmail.com',
    'DBTEMpire@gmail.com',
    'MorenoITF@gmail.com',
    'Tale$@gmail.com',
]
listContrasenias = [
    'KiddKeoInTheMouse123',
    'EnryK123',
    'YayMusic123',
    'Quevedo123',
    'Aitana123',
    'SinNombre123',
    'YungBeef123',
    'LaPantera123',
    'Pitbull123',
    'RelsB123',
    'DeLaRose123',
    'DeLaGetto123',
    'Sech123',
    'BadBunny123',
    'ChenchoCorleone123',
    'JHAYCO123',
    'RauwAlejandro123',
    'BombaEstereo123',
    'TheMarias123',
    'Buscabulla123',
    'Tainy123',
    'MykeTowers123',
    'Farruko123',
    'DarkPoloGang123',
    'KikoElCrazy123',
    'KingShooter123',
    'YoungMA123',
    'Aleman123',
    'sickLuke123',
    'YungSarria123',
    'BladeBrown123',
    'Poundz123',
    'AlvaroDiaz123',
    'Feid123',
    'SanSera123',
    'YoungCister123',
    'Nsqk123',
    'paopao123',
    'Mora123',
    'ARON123',
    'EladioCarrion123',
    'Dalex123',
    'Arcangel123',
    'Lyanno123',
    'Brray123',
    'Brytiago123',
    'MikyWoodz123',
    'Zion&Lennox123',
    'Wisin&Yandel123',
    'Amenazzy123',
    'Lunay123',
    'JBalvin123',
    'ÑengoFlow123',
    'Smokepur123',
    'JonZ123',
    'Noriel123',
    'Cazzu123',
    'Cosculluela123',
    'LilMosey123',
    'Zion123',
    'BandoBoyz123',
    'Neelo123',
    'REYPHARAOH123',
    'SwaggGlock123',
    'Elegvngster123',
    'RenzoGoRellah123',
    'NdKoni123',
    'RaiNao123',
    'Chuwi123',
    'OmarCourtz123',
    'DeiV123',
    'LosPlenerosDeLaCresta123',
    'ElPatron970123',
    'DBTEMpire123',
    'MorenoITF123',
    'Tale$123',
]
listCodigos = [
    '0VZrPa7mWAYXH4CwmYk8Km',
    '05trgdoIUvlwqNLEPHTdoI',
    '65UC5VKwU4vBSBSHckQd5l',
    '52iwsT98xCoGgiGntTiR7K',
    '7eLcDZDYHXZCebtQmVFL25',
    '0b4EVanoJb8wkWF7QUA3uY',
    '1rTUwYS38LkQTlT2fhikch',
    '0IEzMvarfVycBJAXjjEZOL',
    '0TnOYISbd1XYRBk9myaseg',
    '2IMZYfNi21MGqxopj9fWx8',
    '54seKvtsZauR1iauN0ptpo',
    '3EiLUeyEcA6fbRPSHkG5kb',
    '77ziqFxp5gaInVrF2lj4ht',
    '4q3ewBCX7sLwd24euuV69X',
    '37230BxxYs9ksS7OkZw3IU',
    '6nVcHLIgY5pE2YCl8ubca1',
    '3LKXWvXFWrkwUzJWxzwVpW',
    '1mcTU81TzQhprhouKaTkpq',
    '5n9bMYfz9qss2VOW89EVs2',
    '2sSGPbdZJkaSE2AbcGOACx',
    '0MoaBi6dSquXp6rrlqlF8R',
    '0GM7qgcRCORpGnfcN2tCiB',
    '7iK8PXO48WeuP03g8YR51W',
    '329e4yvIujISKGKz1BZZbO',
    '4CuMwzDzEdlUJMEna38VQ0',
    '3NpG6SsHaQETkdQVZH6V1E',
    '26UoKrssddWo79IlVZsj5n',
    '7LvoDJUNGnOrPdGRzVtOJ9',
    '4QFG9KrGWEbr6hNA58CAqE',
    '0hk4xVujcyOr6USD95wcWb',
    '3vxYNXtM9uOMdRAXTXgtmf',
    '4E0mDf341TLViBbNefSrsK',
    '2jItxZsB8PA3vday7b0RLT',
    '5J7rXWjtn5HzUkJ4Jet8Fr',
    '2LRoIwlKmHjgvigdNGBHNo',
    '5lWasZeo8uWQk6GD8czJLq',
    '0Yg29FX1M4ayqjXs0ttZFq',
    '1jtvmXiemNFkPO11NMdjfu',
    '5AS4y4rlmbUYDCdg35qmI9',
    '0Q8NcsJwoCbZOHHW63su5S',
    '0KPX4Ucy9dk82uj4GpKesn',
    '4SsVbpTthjScTS7U2hmr1X',
    '1Ts9of7VPZElwPQnqnDSfW',
    '1GKIlPFdcewHtpDVCQ8zmJ',
    '00XhexlJEXQstHimpZN910',
    '1pf0MPKfKdvS8J779mS1Ay',
    '21451j1KhjAiaYKflxBjr1',
    '1wZtkThiXbVNtj6hee6dz9',
    '47MpMsUfWtgyIIBEFOr4FE',
    '6kq4GHwUcUojGIu0ziSNXf',
    '1vyhD5VmyZ7KMfW5gqLgo5',
    '12vb80Km0Ew53ABfJOepVz',
    '21dooacK2WGBB5amYvKyfM',
    '5bWUlnPx9OYKsLiUJrhCA1',
    '3RtNN1VnooWEn3KQk03DUL',
    '6w3SkAHYPsQ1bxV7VDlG5y',
    '00me4Ke1LsvMxt5kydlMyU',
    '5zctI4wO9XSKS8XwcnqEHk',
    '1pgDilWYDWLoOgGjf1iHNu',
    '70XzZgaGEVlwRN4aPMRtRM',
    '2ENPnSzAeiXxEGFVQffe5q',
    '7c3BPLIHyNxXiX0GPDYO15',
    '0TQ494EpT0cwX3JWh87nOr',
    '0sIhKDdIuQ9pFPJbnvHlfb',
    '5y36EmYcewgdk26jtI1XiZ',
    '65vpTU1WPlaRYEX5UKTfrl',
    '42LEQxfXLEuzdqorKBbUVN',
    '6wF1Cz760dpdbX9RJIDpQW',
    '3E12tRURRvPfHz0hAMCFYc',
    '2YRyPiW98bpkARAS4B3OQP',
    '1uZVxckdGGKhFMpCnupXmP',
    '2rPOaAdN74S2D0Kw3ImL5O',
    '4oxhyBLmPNypRfH9ScegNc',
    '5el3ACLFyuXCtnjXIAvZxc',
    '5w9YZfwWPTeCQn6QEGieIU',
]

# for pais,correo,contrasenia,codigos in zip(listPais,listCorreos,listContrasenias,listCodigos):
#     print(f"{pais} -- {correo} -- {contrasenia} -- {codigos}")

id_usuario = 0
for pais,correo,contrasenia,codigos in zip(listPais,listCorreos,listContrasenias,listCodigos):
    id_usuario+=1
    ObtenerArtista(codigos,pais,correo,contrasenia,id_usuario)