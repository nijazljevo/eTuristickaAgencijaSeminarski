// ignore_for_file: avoid_print, use_build_context_synchronously

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../models/hotel.dart';
import '../models/korisnik.dart';
class Rezervacija{
  final int id;
  final double cijena;
  final int? hotelId;
  final bool otkazana;
  final String datumRezervacije;
  final int? korisnikId;
  Rezervacija({
    required this.id,
    required this.cijena,
    required this.hotelId,
    required this.otkazana,
    required this.datumRezervacije,
    required this.korisnikId,
  });

  Map<String, dynamic> toJson() {
    Map<String, dynamic> json = {
      'id': id,
      'cijena': cijena,
      'hotelId': hotelId,
      'otkazana': otkazana,
      'datumRezervacije': datumRezervacije,
      'korisnikId': korisnikId,
    };

    return json;
  }
}

class DodavanjeRezervacijeScreen extends StatefulWidget {
  
  final Rezervacija? rezervacija;

  const DodavanjeRezervacijeScreen({Key? key, this.rezervacija}) : super(key: key);
  @override
  // ignore: library_private_types_in_public_api
  _DodavanjeRezervacijeScreenState createState() =>
      _DodavanjeRezervacijeScreenState();
}

class _DodavanjeRezervacijeScreenState
    extends State<DodavanjeRezervacijeScreen> {
  final _formKey = GlobalKey<FormState>();
  // ignore: prefer_final_fields
  TextEditingController _cijenaController = TextEditingController();
  late int _selectedKorisnikId;
  List<Korisnik> _korisnik = [];
  late int _selectedHotelId;
  List<Hotel> _hotel = [];
  late bool _isCanceled = false;
  late DateTime _selectedDate=DateTime.now();
  bool isLoading = true;
  Hotel? selectedHotel;
  Korisnik? selectedKorisnik;
  @override
  void initState() {
    super.initState();
    _selectedHotelId = -1;
    _selectedKorisnikId = -1;
    fetchKorisnik();
    fetchHotel();
      if (widget.rezervacija != null) {
      _cijenaController.text = widget.rezervacija!.cijena.toString() ;
     if (widget.rezervacija != null) {
  _cijenaController.text = widget.rezervacija!.cijena.toString();
  if (_hotel.isNotEmpty && widget.rezervacija!.hotelId != null) {
    selectedHotel = _hotel.firstWhere(
        (hotel) => hotel.id == widget.rezervacija!.hotelId);
  }
  if (_korisnik.isNotEmpty && widget.rezervacija!.korisnikId != null) {
    selectedKorisnik = _korisnik.firstWhere(
        (korisnik) => korisnik.id == widget.rezervacija!.korisnikId);
  }
}

    }
  }

  @override
  void dispose() {
    _cijenaController.dispose();
    super.dispose();
  }

 Future<void> fetchKorisnik() async {
    final response =
        await http.get(Uri.parse('http://localhost:5011/api/Korisnici'));
    if (response.statusCode == 200) {
      final List<dynamic> responseData = jsonDecode(response.body);
      setState(() {
        _korisnik =
            responseData.map((data) => Korisnik.fromJson(data)).toList();
        _selectedKorisnikId =
            (_korisnik.isNotEmpty ? _korisnik.first.id : -1)!;
      });
    }
  }
    Future<void> fetchHotel() async {
    final response =
        await http.get(Uri.parse('http://localhost:5011/api/Hoteli'));
    if (response.statusCode == 200) {
      final List<dynamic> responseData = jsonDecode(response.body);
      setState(() {
        _hotel = responseData.map((data) => Hotel.fromJson(data)).toList();
        _selectedHotelId = (_hotel.isNotEmpty ? _hotel.first.id : -1)!;
      });
    }
  }

  Future<void> addRezervacija(Rezervacija novaRezervacija) async {
    final response = await http.post(
      Uri.parse('http://localhost:5011/api/Rezervacija'),
      headers: {'Content-Type': 'application/json'},
      body: jsonEncode(novaRezervacija.toJson()),
    );
     print(response.body);

    if (response.statusCode == 200) {
      showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: const Text('Success'),
            content: const Text('Reservation added successfully.'),
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
      showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: const Text('Error'),
            content: const Text('Failed to add reservation.'),
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
   Future<void> editReservation(Rezervacija rezervacija) async {
    final updatedRezervacija =
        Rezervacija(id: rezervacija.id, cijena: rezervacija.cijena, hotelId: rezervacija.hotelId,datumRezervacije: rezervacija.datumRezervacije,korisnikId: rezervacija.korisnikId,otkazana: rezervacija.otkazana);

    final response = await http.put(
      Uri.parse('http://localhost:5011/api/Rezervacija/${rezervacija.id}'),
      headers: {'Content-Type': 'application/json'},
      body: jsonEncode(updatedRezervacija.toJson()),
    );

    print('Response status code: ${response.statusCode}');
    print('Response body: ${response.body}');

    if (response.statusCode == 200) {
      showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: const Text('Success'),
            content: const Text('Reservation updated successfully.'),
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
      showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: const Text('Error'),
            content: const Text('Failed to update reservation.'),
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

  void _submitForm() {
    if (_formKey.currentState!.validate()) {
      final double cijena = double.parse( _cijenaController.text.trim());
       final DateTime formattedDate = DateTime(
      _selectedDate.year,
      _selectedDate.month,
      _selectedDate.day,
    );
      final Rezervacija novaRezervacija = Rezervacija(
        id: widget.rezervacija?.id ?? 0,
        cijena:cijena,
        korisnikId: _selectedKorisnikId,
        hotelId: _selectedHotelId,
        otkazana: _isCanceled,
        datumRezervacije:formattedDate.toIso8601String(),

      );

       if (widget.rezervacija != null) {
        editReservation(novaRezervacija);
      } else {
        addRezervacija(novaRezervacija);
      }
    }
  }
 Future<void> _selectDate(BuildContext context) async {
    final DateTime? picked = await showDatePicker(
      context: context,
      initialDate: _selectedDate,
      firstDate: DateTime(1900),
      lastDate: DateTime(2100),
    );
    if (picked != null && picked != _selectedDate)
      // ignore: curly_braces_in_flow_control_structures
      setState(() {
        _selectedDate = picked;
      });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Add reservation'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Form(
          key: _formKey,
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              TextFormField(
                controller: _cijenaController,
                decoration: const InputDecoration(
                  labelText: ' cijena',
                ),
                validator: (value) {
                  if (value!.isEmpty) {
                    return 'Please enter price.';
                  }
                  return null;
                },
              ),
              const SizedBox(height: 16.0),
              const Text('Select User:'),
              DropdownButton<int>(
                value: _selectedKorisnikId,
                onChanged: (int? newValue) {
                  setState(() {
                    _selectedKorisnikId = newValue!;
                  });
                },
                items: _korisnik.map((Korisnik uloga) {
                  return DropdownMenuItem<int>(
                    value: uloga.id,
                    // ignore: prefer_interpolation_to_compose_strings
                    child: Text(uloga.ime! + " " + uloga.prezime!),
                  );
                }).toList(),
              ),
              const SizedBox(height: 16.0),
              const Text('Select Hotel:'),
              DropdownButton<int>(
                value: _selectedHotelId,
                onChanged: (int? newValue) {
                  setState(() {
                    _selectedHotelId = newValue!;
                  });
                },
                items: _hotel.map((Hotel uloga) {
                  return DropdownMenuItem<int>(
                    value: uloga.id,
                    child: Text(uloga.naziv!),
                  );
                }).toList(),
              ),
              const SizedBox(height: 16.0),
              Row(
                children: [
                  const Text('Is Canceled:'),
                  Checkbox(
                    value: _isCanceled,
                    onChanged: (bool? newValue) {
                      setState(() {
                        _isCanceled = newValue!;
                      });
                    },
                  ),
                ],
              ),
                const SizedBox(height: 16.0),
              ElevatedButton(
                onPressed: () => _selectDate(context),
                child: const Text('Select Date'),
              ),
              const SizedBox(height: 16.0),
              // ignore: unnecessary_null_comparison
              if (_selectedDate != null)
                Text(
                  'Selected Date: ${_selectedDate.toString()}',
                  style: const TextStyle(fontWeight: FontWeight.bold),
                ),
              const SizedBox(height: 16.0),

              ElevatedButton(
                onPressed: _submitForm,
                child: const Text('Add'),
              ),
            ],
          ),
        ),
      ),
    );
  }
}


