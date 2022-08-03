import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import '../models/korisnik.dart';
import '../services/APIservice.dart';

class Profil extends StatefulWidget {
  const Profil({Key? key}) : super(key: key);

  @override
  State<Profil> createState() => _ProfilState();
}

class _ProfilState extends State<Profil> {
  TextEditingController imeController = TextEditingController();
  TextEditingController prezimeController = TextEditingController();
  TextEditingController korisnickoImeController = TextEditingController();
  TextEditingController emailController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: const Text('Moj profil'),
          backgroundColor: Colors.blue[900],
        ),
        body: bodyWidget());
  }

  Widget bodyWidget() {
    Widget ProfilWidget(korisnik) {
      imeController.text = korisnik.ime;
      prezimeController.text = korisnik.prezime;
      korisnickoImeController.text = korisnik.KorisnikoIme;
      emailController.text = korisnik.email;
      return Card(
          child: Center(
              child: SingleChildScrollView(
                  child: Padding(
        padding: const EdgeInsets.all(50),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.start,
          children: [
            Form(
                child: Column(
              children: [
                const Text(
                  'Ime',
                  style: TextStyle(fontSize: 20, color: Colors.black),
                ),
                SizedBox(
                  height: 35,
                  child: TextFormField(
                      controller: imeController,
                      style:
                          const TextStyle(fontSize: 15, color: Colors.black)),
                ),
                const SizedBox(
                  height: 10,
                ),
                const Text(
                  'Prezime',
                  style: TextStyle(fontSize: 20, color: Colors.black),
                ),
                SizedBox(
                  height: 35,
                  child: TextFormField(
                      controller: prezimeController,
                      style:
                          const TextStyle(fontSize: 15, color: Colors.black)),
                ),
                const SizedBox(
                  height: 10,
                ),
                const Text(
                  'E-mail',
                  style: TextStyle(fontSize: 20, color: Colors.black),
                ),
                SizedBox(
                  height: 35,
                  child: TextFormField(
                      controller: emailController,
                      style:
                          const TextStyle(fontSize: 15, color: Colors.black)),
                ),
                const SizedBox(
                  height: 10,
                ),
               
                const Text(
                  'Korisničko ime',
                  style: TextStyle(fontSize: 20, color: Colors.black),
                ),
                SizedBox(
                  height: 35,
                  child: TextFormField(
                      controller: korisnickoImeController,
                      style:
                          const TextStyle(fontSize: 15, color: Colors.black)),
                ),
                const SizedBox(
                  height: 10,
                ),
                Padding(
                  padding: const EdgeInsets.all(5),
                  child: ElevatedButton(
                    onPressed: () async {
                     
                      var request = Korisnik(
                          ime: imeController.text,
                          prezime: prezimeController.text,
                          email: emailController.text,
                          KorisnikoIme: korisnickoImeController.text);

                      var result = await APIService.put("Korisnici",
                          APIService.korisnikId, json.encode(request.toJson()));

                      if (result != null) {
                        setState(() {
                          ScaffoldMessenger.of(context)
                              .showSnackBar(const SnackBar(
                            content: SizedBox(
                                height: 20,
                                child:
                                    Center(child: Text("Uspješno sačuvano."))),
                            backgroundColor: Color.fromARGB(255, 9, 100, 13),
                          ));
                        });
                      }
                    },
                    style: ElevatedButton.styleFrom(
                        primary: Colors.green[900],
                        padding: const EdgeInsets.symmetric(
                            horizontal: 20, vertical: 10)),
                    child: const Text('Sačuvaj'),
                  ),
                )
              ],
            ))
          ],
        ),
      ))));
    }

    return FutureBuilder<Korisnik>(
      future: getPodaci(),
      builder: (BuildContext context, AsyncSnapshot<Korisnik> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return const Center(child: Text('Loading..'));
        } else {
          if (snapshot.hasError) {
            return Center(child: Text('Error:${snapshot.error}'));
          } else {
            return ProfilWidget(snapshot.data);
          }
        }
      },
    );
  }

  Future<Korisnik> getPodaci() async {
    var rez =
        await APIService.getByIdKorisnik('Korisnici', APIService.korisnikId);
    return Korisnik.fromJson(rez);
  }
}