// ignore_for_file: avoid_print

import 'dart:convert';
import 'dart:io';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:image_picker/image_picker.dart';
import '../models/korisnik.dart';

class Korisnik1 {
 final int id;
  final String ime;
  final String prezime;
  final String email;
  final String korisnikoIme;
  final String password;
  final String passwordPotvrda;
  final int ulogaId;
  final String slika;

  Korisnik1({required this.id,
    required this.ime,
    required this.prezime,
    required this.email,
    required this.korisnikoIme,
    required this.password,
    required this.passwordPotvrda,
    required this.ulogaId,
    required this.slika});

  Map<String, dynamic> toJson() {
    Map<String, dynamic> json = {
      'id':id,
      'ime': ime,
      'prezime': prezime,
      'email': email,
      'korisnikoIme': korisnikoIme,
      'password': password,
      'passwordPotvrda': passwordPotvrda,
      'ulogaId': ulogaId,
      'slika':slika,
    };

    return json;
  }
}


class KorisnikDetailsScreen extends StatefulWidget {
  final Korisnik? korisnik;

  const KorisnikDetailsScreen({Key? key, this.korisnik}) : super(key: key);

  @override
  // ignore: library_private_types_in_public_api
  _KorisnikDetailsScreenState createState() => _KorisnikDetailsScreenState();
}

class _KorisnikDetailsScreenState extends State<KorisnikDetailsScreen> {
  final _formKey = GlobalKey<FormState>();
  late TextEditingController _imeController;
  late TextEditingController _prezimeController;
  late TextEditingController _emailController;
  late TextEditingController _korisnickoImeController;
  late TextEditingController _passwordController;
  late TextEditingController _passowrdPotvrdaController;
  List<Uloga> uloga = [];
  Uloga? selectedUloga;
  bool isLoading = true;
  File? selectedImage;

  @override
  void initState() {
    super.initState();
    fetchUloge();
    _imeController = TextEditingController();
    _prezimeController = TextEditingController();
    _emailController = TextEditingController();
    _korisnickoImeController = TextEditingController();
    _passwordController = TextEditingController();
    _passowrdPotvrdaController = TextEditingController();
      if (widget.korisnik != null) {
      _imeController.text = widget.korisnik!.ime!;
      _prezimeController.text = widget.korisnik!.prezime!;
      _emailController.text = widget.korisnik!.email!;
      _korisnickoImeController.text = widget.korisnik!.korisnikoIme!;
   
    }
  }

  Future<void> fetchUloge() async {

    try {
      const url =
          'http://localhost:5011/api/Uloge';
      final response = await http.get(Uri.parse(url));

      if (response.statusCode == 200) {
        final List<dynamic> responseData = json.decode(response.body);
        uloga = responseData.map((data) {
          return Uloga(
            id: data['id'],
            naziv: data['naziv'],
          );
        }).toList();
      } else {
        throw Exception('Failed to fetch uloge');
      }
    } catch (error) {
      print(error);
    }

    setState(() {});
  }

  Future<void> addKorisnik(Korisnik1 noviKorisnik) async {
    final response = await http.post(
      Uri.parse('http://localhost:5011/api/Korisnici'),
      headers: {'Content-Type': 'application/json'},
      body: jsonEncode(noviKorisnik.toJson()),
    );

    if (response.statusCode == 200) {
      // ignore: use_build_context_synchronously
      showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: const Text('Success'),
            content: const Text('Korisnik added successfully.'),
            actions: [
              TextButton(
                onPressed: () => Navigator.pop(context),
                child: const Text('OK'),
              ),
            ],
          );
        },
      );
    } else {
      print('Error: ${response.statusCode}');
      print('Response body: ${response.body}');

      // ignore: use_build_context_synchronously
      showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: const Text('Error'),
            content: const Text('Failed to add korisnik.'),
            actions: [
              TextButton(
                onPressed: () => Navigator.pop(context),
                child: const Text('OK'),
              ),
            ],
          );
        },
      );
    }
  }
  Future<void> editKorisnik(Korisnik1 korisnik) async {
   final updatedKorisnik = Korisnik1(
    id: korisnik.id,
    ime: korisnik.ime,
    prezime: korisnik.prezime,
    email: korisnik.email,
    korisnikoIme: korisnik.korisnikoIme,
    password: korisnik.password,
    passwordPotvrda: korisnik.passwordPotvrda,
    ulogaId: korisnik.ulogaId,
    slika: korisnik.slika
  );
    final response = await http.put(
      Uri.parse('http://localhost:5011/api/Korisnici/${korisnik.id}'),
      headers: {'Content-Type': 'application/json'},
      body: jsonEncode(updatedKorisnik.toJson()),
    );

    print('Response status code: ${response.statusCode}');
    print('Response body: ${response.body}');

    if (response.statusCode == 200) {
      // ignore: use_build_context_synchronously
      showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: const Text('Success'),
            content: const Text('Korisnik updated successfully.'),
            actions: [
              TextButton(
                onPressed: () => Navigator.pop(context),
                child: const Text('OK'),
              ),
            ],
          );
        },
      );
    } else {
      // ignore: use_build_context_synchronously
      showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: const Text('Error'),
            content: const Text('Failed to update korisnik.'),
            actions: [
              TextButton(
                onPressed: () => Navigator.pop(context),
                child: const Text('OK'),
              ),
            ],
          );
        },
      );
    }
  }
   Future<void> pickImage() async {
    // ignore: deprecated_member_use
    final pickedImage = await ImagePicker().getImage(source: ImageSource.gallery);
    if (pickedImage != null) {
      setState(() {
        selectedImage = File(pickedImage.path);
      });
    }
  }

  void _submitForm() {
    if (_formKey.currentState!.validate()) {
      final String ime = _imeController.text;
      final String prezime = _prezimeController.text;
      final String email = _emailController.text;
      final String korisnikoIme = _korisnickoImeController.text;
      final String password = _passwordController.text;
      final String passwordPotvrda = _passowrdPotvrdaController.text;

      final Korisnik1 noviKorisnik = Korisnik1(
        id:widget.korisnik?.id ?? 0,
        ime: ime,
        prezime: prezime,
        email: email,
        korisnikoIme: korisnikoIme,
        password: password,
        passwordPotvrda: passwordPotvrda,
        ulogaId: selectedUloga!.id,
        slika: selectedImage != null ? base64Encode(selectedImage!.readAsBytesSync()) : '',
      );

        if (widget.korisnik != null) {
        editKorisnik(noviKorisnik);
      } else {
        addKorisnik(noviKorisnik);
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Dodaj korisnika'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Form(
          key: _formKey,
          child: Column(
            children: [
              TextFormField(
                controller: _imeController,
                decoration: const InputDecoration(labelText: 'Ime'),
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Molimo unesite ime korisnika.';
                  }
                  return null;
                },
              ),
               TextFormField(
                controller: _prezimeController,
                decoration: const InputDecoration(labelText: 'Prezime'),
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Molimo unesite prezime korisnika.';
                  }
                  return null;
                },
              ),
               TextFormField(
                controller: _emailController,
                decoration: const InputDecoration(labelText: 'Email'),
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Molimo unesite email korisnika.';
                  }
                  return null;
                },
              ),
               TextFormField(
                controller: _korisnickoImeController,
                decoration: const InputDecoration(labelText: 'Korisnicko ime'),
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Molimo unesite korisnicko ime korisnika.';
                  }
                  return null;
                },
              ),
                 TextFormField(
                controller: _passwordController,
                decoration: const InputDecoration(labelText: 'Password'),
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Molimo unesite password.';
                  }
                  return null;
                },
              ),
               TextFormField(
                controller: _passowrdPotvrdaController,
                decoration: const InputDecoration(labelText: 'Potvrda password'),
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Molimo potvrdite password.';
                  }
                  return null;
                },
              ),
              DropdownButtonFormField<Uloga>(
                value: selectedUloga,
                items: uloga.map((uloga) {
                  return DropdownMenuItem<Uloga>(
                    value: uloga,
                    child: Text(uloga.naziv),
                  );
                }).toList(),
                onChanged: (Uloga? newValue) {
                  setState(() {
                    selectedUloga = newValue;
                  });
                },
                decoration: const InputDecoration(labelText: 'Uloga'),
                validator: (value) {
                  if (value == null) {
                    return 'Molimo odaberite ulogu.';
                  }
                  return null;
                },
              ),
              const SizedBox(height: 16.0),
              ElevatedButton(
                onPressed: pickImage,
                child: const Text('Odaberite sliku'),
              ),
              const SizedBox(height: 16.0),
              ElevatedButton(
                onPressed: _submitForm,
                child: const Text('Dodaj'),
              ),
            ],
          ),
        ),
      ),
    );
  }
}


class Uloga {
  final int id;
  final String naziv;

  Uloga({
    required this.id,
    required this.naziv,
  });
}

