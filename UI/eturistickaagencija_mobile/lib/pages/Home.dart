// ignore: file_names
import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import '../model/destinacija.dart';
import '../model/ocjena.dart';
import 'DestinacijaDetails.dart';

class Home extends StatefulWidget {
  const Home({Key? key}) : super(key: key);

  @override
  // ignore: library_private_types_in_public_api
  _HomeState createState() => _HomeState();
}

class _HomeState extends State<Home> {
  Future<List<Ocjena>?> getPreporuceno() async {
    try {
      final response = await http.get(Uri.parse('http://10.0.2.2:5011/api/Ocjene'));
      // ignore: avoid_print
      print(response.body);
      if (response.statusCode == 200) {
        final List<dynamic> jsonList = json.decode(response.body);
        // ignore: avoid_print
        print('Response Body: $jsonList'); 
        List<Ocjena> preporuceno = jsonList.map((json) => Ocjena.fromJson(json)).toList();
        preporuceno.sort((a, b) => b.ocjenaUsluge!.compareTo(a.ocjenaUsluge!)); 
        return preporuceno;
      }
    } catch (e) {
      // ignore: avoid_print
      print('Error: $e');
    }
    return null;
  }

  Future<Destinacija?> getDestinacija(int? destinacijaId) async {
    try {
      final response = await http.get(Uri.parse('http://10.0.2.2:5011/api/Destinacije/$destinacijaId'));
      // ignore: avoid_print
      print(response.body);
      if (response.statusCode == 200) {
        final Map<String, dynamic> jsonData = json.decode(response.body);
        // ignore: avoid_print
        print('Response Body: $jsonData'); 
        Destinacija destinacija = Destinacija.fromJson(jsonData);
        return destinacija;
      }
    } catch (e) {
      // ignore: avoid_print
      print('Error: $e');
    }
    return null;
  }

  Widget preporucenaHotelWidget(Ocjena ocjena) {
    return FutureBuilder<Destinacija?>(
      future: getDestinacija(ocjena.destinacijaId),
      builder: (BuildContext context, AsyncSnapshot<Destinacija?> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return const Center(child: CircularProgressIndicator());
        } else {
          if (snapshot.hasError) {
            return Center(child: Text('Error: ${snapshot.error}'));
          } else {
            if (snapshot.hasData && snapshot.data != null) {
              Destinacija destinacija = snapshot.data!;
              return InkWell(
                onTap: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                      builder: (context) => DestinacijaDetailsScreen(destinacija: destinacija),
                    ),
                  );
                },
                child: Card(
                  child: Padding(
                    padding: const EdgeInsets.all(10),
                    child: Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: [
                            Text(
                              'Destinacija: ${destinacija.naziv}',
                              style: const TextStyle(
                                color: Colors.black,
                                fontSize: 16,
                                fontWeight: FontWeight.bold,
                              ),
                            ),
                            const SizedBox(height: 5),
                            Text(
                              'Ocjena usluge: ${ocjena.ocjenaUsluge}',
                              style: const TextStyle(
                                color: Colors.black,
                                fontSize: 14,
                              ),
                            ),
                            Text(
                              'Komentar: ${ocjena.komentar}',
                              style: const TextStyle(
                                color: Colors.black,
                                fontSize: 14,
                              ),
                            ),
                          ],
                        ),
                      ],
                    ),
                  ),
                ),
              );
            } else {
              return const Center(
                child: Text(
                  "Nema dovoljno podataka za prikaz.",
                  style: TextStyle(fontSize: 18),
                ),
              );
            }
          }
        }
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            const Text('Pocetna'),
            InkWell(
              onTap: () => {
                Navigator.of(context)
                    .pushNamed('Korpa')
                    .then((_) => setState(() {}))
              },
            )
          ],
        ),
      ),
      drawer: Drawer(
        child: Column(
          children: [
            AppBar(
              title: const Text("Meni"),
              centerTitle: true,
            ),
            const Divider(),
            ListTile(
              leading: const Icon(Icons.home),
              title: const Text("Pocetna"),
              onTap: () {
                Navigator.of(context).pushReplacementNamed('Home');
              },
            ),
          
            const Divider(),
            ListTile(
              leading: const Icon(Icons.person),
              title: const Text("Profil"),
              onTap: () {
                Navigator.of(context).pushNamed('Profil');
              },
            ),
            const Divider(),
            ListTile(
              leading: const Icon(Icons.hotel),
              title: const Text("Hotel"),
              onTap: () {
                Navigator.of(context).pushNamed('HotelListPage');
              },
            ),
            ListTile(
              leading: const Icon(Icons.airplane_ticket),
              title: const Text("Destinacija"),
              onTap: () {
                Navigator.of(context).pushNamed('DestinacijaListPage');
              },
            ),
              
           
            const Divider(),
            ListTile(
              leading: const Icon(Icons.logout),
              title: const Text("Odjava"),
              onTap: () {
                Navigator.of(context).pushReplacementNamed('/');
              },
            ),
          ],
        ),
      ),
      body: Column(
        children: [
          const Padding(
            padding: EdgeInsets.all(10.0),
            child: Align(
              alignment: Alignment.centerLeft,
              child: Text('Preporuceno', style: TextStyle(fontWeight: FontWeight.w600, fontSize: 25)),
            ),
          ),
          Flexible(
            child: FutureBuilder<List<Ocjena>?>(
              future: getPreporuceno(),
              builder: (BuildContext context, AsyncSnapshot<List<Ocjena>?> snapshot) {
                if (snapshot.connectionState == ConnectionState.waiting) {
                  return const Center(child: CircularProgressIndicator());
                } else {
                  if (snapshot.hasError) {
                    return Center(child: Text('Error: ${snapshot.error}'));
                  } else {
                    if (snapshot.hasData && snapshot.data!.isNotEmpty) {
                      snapshot.data!.sort((a, b) => b.ocjenaUsluge!.compareTo(a.ocjenaUsluge!));

                      return ListView.builder(
                        itemCount: snapshot.data!.length,
                        itemBuilder: (BuildContext context, int index) {
                          Ocjena ocjena = snapshot.data![index];
                          return preporucenaHotelWidget(ocjena);
                        },
                      );
                    } else {
                      return const Center(
                        child: Text(
                          "Nema dovoljno podataka za prikaz.",
                          style: TextStyle(fontSize: 18),
                        ),
                      );
                    }
                  }
                }
              },
            ),
          ),
        ],
      ),
    );
  }
}
