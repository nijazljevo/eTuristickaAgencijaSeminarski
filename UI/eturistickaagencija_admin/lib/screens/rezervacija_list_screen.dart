import 'dart:convert';
import 'package:eturistickaagencija_admin/screens/rezervacija_details_screen.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

class RezervacijeScreen extends StatefulWidget {
  @override
  _RezervacijeScreenState createState() => _RezervacijeScreenState();
}

class _RezervacijeScreenState extends State<RezervacijeScreen> {
  List<Rezervacija> rezervacija = [];
  List<Hotel> hotel = [];
  List<Korisnik> korisnik = [];

  final TextEditingController cijenaController = TextEditingController();

  @override
  void initState() {
    super.initState();
  }

  Future<void> searchRezervacije() async {
  double cijena = double.tryParse(cijenaController.text) ?? 0;
  int hotelId = 0; // Get the selected value from the dropdown
  int korisnikId = 0;

  try {
    final url =
        'http://localhost:5011/api/Rezervacija?cijena=$cijena&hotelId=$hotelId&korisnikId=$korisnikId';
    final response = await http.get(Uri.parse(url));

    if (response.statusCode == 200) {
      final List<dynamic> responseData = json.decode(response.body);
      rezervacija = responseData.map((data) {
        DateTime? datumRezervacije = data['datumRezervacije'] != null
            ? DateTime.parse(data['datumRezervacije'])
            : null;
        return Rezervacija(
          id: data['id'],
          cijena: data['cijena'],
          datumRezervacije: datumRezervacije.toString(),
          otkazana: data['otkazana'],
          hotelId: data['hotelId'],
          korisnikId: data['korisnikId'],
        );
      }).toList();
    } else {
      throw Exception('Failed to fetch rezervacija');
    }
  } catch (error) {
    print(error);
  }

  setState(() {
    if (rezervacija.isEmpty) {
      // Prikazati poruku ako nema rezultata pretrage
      showDialog(
        context: context,
        builder: (context) => AlertDialog(
          title: Text('Nema rezultata'),
          content: Text('Nema rezervacija s unesenom cijenom.'),
          actions: [
            TextButton(
              onPressed: () {
                Navigator.of(context).pop();
              },
              child: Text('OK'),
            ),
          ],
        ),
      );
    }
  });
}

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Rezervacije'),
      ),
      body: Column(
        children: [
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: Row(
              children: [
                Expanded(
                  child: TextField(
                    controller: cijenaController,
                    decoration: InputDecoration(
                      labelText: 'Cijena',
                    ),
                  ),
                ),
                SizedBox(width: 8),
                DropdownButton<Hotel>(
                  value: hotel.isNotEmpty ? hotel[0] : null,
                  onChanged: (value) {
                    // Handle dropdown value change
                    // You may store the value in a variable and use it for searching
                  },
                  items: hotel.map((hotel) {
                    return DropdownMenuItem<Hotel>(
                      value: hotel,
                      child: Text(hotel.naziv),
                    );
                  }).toList(),
                ),
                SizedBox(width: 8),
                ElevatedButton(
                  onPressed: () {
                    // Handle search button click
                    // You can use the entered values to search for drzave
                    searchRezervacije();
                  },
                  child: Text('Pretraga'),
                ),
                SizedBox(width: 8),
                ElevatedButton(
                  onPressed: () async {
                    Navigator.of(context).push(
                      MaterialPageRoute(
                        builder: (context) => DodavanjeRezervacijeScreen(),
                      ),
                    );
                  },
                  child: Text("Dodaj"),
                )
              ],
            ),
          ),
          Expanded(
            child: DataTable(
              columns: const [
                DataColumn(label: Text('ID')),
                DataColumn(label: Text('Cijena')),
                DataColumn(label: Text('Datum rezervacije')),
              ],
              rows: rezervacija
                      .map(
                        (Rezervacija e) => DataRow(
                          onSelectChanged: (selected) {
                            if (selected == true) {
                              Navigator.of(context).push(
                                MaterialPageRoute(
                                  builder: (context) => DodavanjeRezervacijeScreen(rezervacija: e),
                                ),
                              );
                            }
                          },
                          cells: [
                            DataCell(Text(e.id.toString())),
                            DataCell(Text(e.cijena.toString())),
                            DataCell(Text(
                              e.datumRezervacije != null
                                  ? e.datumRezervacije.toString()
                                  : '',
                            )),
                          ],
                        ),
                      )
                      .toList() ??
                  [],
            ),
          ),
        ],
      ),
    );
  }
}

// class Rezervacija {
//   final int id;
//   final double cijena;
//   final String datumRezervacije;r
//   final bool otkazana;
//   final int hotelId;
//   final int korisnikId;

//   Rezervacija({
//     required this.id,
//     required this.cijena,
//     required this.datumRezervacije,
//     required this.otkazana,
//     required this.hotelId,
//     required this.korisnikId,
//   });
// }

class Hotel {
  final int id;
  final String naziv;

  Hotel({
    required this.id,
    required this.naziv,
  });
}

class Korisnik {
  final int id;
  final String ime;

  Korisnik({
    required this.id,
    required this.ime,
  });
}
