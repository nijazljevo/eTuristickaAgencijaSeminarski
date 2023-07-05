// ignore: file_names
import 'dart:convert';
import 'package:eturistickaagencija_mobile/model/destinacija.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import '../utils/util.dart';
import 'DestinacijaDetails.dart';

class DestinacijaListPage extends StatefulWidget {
  const DestinacijaListPage({super.key});

  @override
  // ignore: library_private_types_in_public_api
  _DestinacijaListPageState createState() => _DestinacijaListPageState();
}

class _DestinacijaListPageState extends State<DestinacijaListPage> {
  List<Destinacija> destinacija = [];
  var rating = 0.0;

  @override
  void initState() {
    super.initState();
  }

  Future<void> searchDestinacije(
      String naziv, int gradId, int drzavaId, int kontinentId) async {
    final url =
        'http://10.0.2.2:5011/api/Destinacije?naziv=$naziv&gradId=$gradId&drzavaId=$drzavaId&kontinentId=$kontinentId';
    final response = await http.get(Uri.parse(url));
    if (response.statusCode == 200) {
      final data = json.decode(response.body);
      setState(() {
        destinacija =
            List<Destinacija>.from(data.map((json) => Destinacija.fromJson(json)));
      });
    } else {
      // ignore: use_build_context_synchronously
      showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: const Text('Greška'),
            content: const Text('Došlo je do greške prilikom dohvata podataka destinacija.'),
            actions: [
              ElevatedButton(
                onPressed: () {
                  Navigator.of(context).pop();
                },
                child: const Text('OK'),
              ),
            ],
          );
        },
      );
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Destinacije'),
      ),
      body: Column(
        children: [
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: Row(
              children: [
                Expanded(
                  child: TextField(
                    decoration: const InputDecoration(
                      labelText: 'Naziv',
                    ),
                    onChanged: (value) {
                      setState(() {
                        searchDestinacije(value, 0, 0, 0);
                      });
                    },
                  ),
                ),
                const SizedBox(width: 8),
                ElevatedButton(
                  onPressed: () {
                    String naziv = '';
                    int kontinentId = 0;
                    int drzavaId = 0;
                    int gradId = 0;
                    searchDestinacije(naziv, gradId, drzavaId, kontinentId);
                  },
                  child: const Text('Pretraga'),
                ),
                const SizedBox(
                  width: 8,
                ),
              ],
            ),
          ),
          Expanded(
            child: DataTable(
              columns: const [
                DataColumn(label: Text('Naziv')),
                DataColumn(label: Text('Slika')),
              ],
              rows: destinacija
                  .map(
                    (Destinacija e) => DataRow(
                      onSelectChanged: (selected) {
                        if (selected == true) {
                          Navigator.of(context).push(
                            MaterialPageRoute(
                              builder: (context) =>
                                  DestinacijaDetailsScreen(destinacija: e),
                            ),
                          );
                        }
                      },
                      cells: [
                        DataCell(Text(e.naziv ?? "")),
                        DataCell(e.slika != null && e.slika != ""
                            ? SizedBox(
                                width: 100,
                                height: 100,
                                child: imageFromBase64String(e.slika!),
                              )
                            : const Text("")),
                      ],
                    ),
                  )
                  .toList(),
            ),
          ),
        ],
      ),
    );
  }
}
