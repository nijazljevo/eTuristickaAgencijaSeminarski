import 'dart:convert';
import 'dart:io';
import 'package:eturistickaagencija_admin/providers/korisnik_provider.dart';
import 'package:eturistickaagencija_admin/providers/uloga_provider.dart';
import 'package:file_picker/file_picker.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:http/http.dart' as http;
import 'package:image_picker/image_picker.dart';
import 'package:provider/provider.dart';

import '../models/korisnik.dart';
import '../models/search_result.dart';
import '../models/uloga.dart';
import '../widgets/master_screen.dart';

class KorisnikDetailsScreen extends StatefulWidget {
  Korisnik? korisnik;
  KorisnikDetailsScreen({Key? key, this.korisnik}) : super(key: key);

  @override
  State<KorisnikDetailsScreen> createState() => _KorisnikDetailsScreenState();
}

class _KorisnikDetailsScreenState extends State<KorisnikDetailsScreen> {
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};
  late UlogaProvider _ulogaProvider;
  late KorisnikProvider _korisnikProvider;

  SearchResult<Uloga>? ulogaResult;
  bool isLoading = true;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _initialValue = {
      'ime': widget.korisnik?.ime,
      'prezime': widget.korisnik?.prezime,
      'email': widget.korisnik?.email,
      'korisnikoIme': widget.korisnik?.korisnikoIme,
      'password': widget.korisnik?.password,
      'passwordPotvrda': widget.korisnik?.passwordPotvrda,
      'ulogaId': widget.korisnik?.ulogaId?.toString(),
    };

    _ulogaProvider = context.read<UlogaProvider>();
    _korisnikProvider = context.read<KorisnikProvider>();

    initForm();
  }

  @override
  void didChangeDependencies() {
    // TODO: implement didChangeDependencies
    super.didChangeDependencies();

   
  }

  Future initForm() async {
    ulogaResult = await _ulogaProvider.get();
    print(ulogaResult);


    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      // ignore: sort_child_properties_last
      child: Column(
        children: [
          isLoading ? Container() : _buildForm(),
          Row(
            mainAxisAlignment: MainAxisAlignment.end,
            children: [
              Padding(
                padding: EdgeInsets.all(10),
                child: ElevatedButton(
                    onPressed: () async {
                      _formKey.currentState?.saveAndValidate();

                      print(_formKey.currentState?.value);
                      print(_formKey.currentState?.value['ime']);

                      var request = new Map.from(_formKey.currentState!.value);

                      request['slika'] = _base64Image;

                      print(request['slika']);
                      
                      try {
                        if (widget.korisnik == null) {
                          await _korisnikProvider
                              .insert(request);
                        } else {
                          await _korisnikProvider.update(
                              widget.korisnik!.id!,
                              request);
                        }
                      } on Exception catch (e) {
                        showDialog(
                            context: context,
                            builder: (BuildContext context) => AlertDialog(
                                  title: Text("Error"),
                                  content: Text(e.toString()),
                                  actions: [
                                    TextButton(
                                        onPressed: () => Navigator.pop(context),
                                        child: Text("OK"))
                                  ],
                                ));
                      }
                    },
                    child: Text("Sačuvaj")),
              )
            ],
          )
        ],
      ),
      title: this.widget.korisnik?.ime ?? "Korisnik details",
    );
  }

  FormBuilder _buildForm() {
    return FormBuilder(
      key: _formKey,
      initialValue: _initialValue,
      child: Column(children: [
        Row(
          children: [
            Expanded(
              child: FormBuilderTextField(
                decoration: InputDecoration(labelText: "Ime"),
                name: "ime",
              ),
            ),
            SizedBox(
              width: 10,
            ),
            Expanded(
              child: FormBuilderTextField(
                decoration: InputDecoration(labelText: "Prezime"),
                name: "prezime",
              ),
            ),
             SizedBox(
              width: 10,
            ),
            Expanded(
              child: FormBuilderTextField(
                decoration: InputDecoration(labelText: "Email"),
                name: "email",
              ),
            ),
             SizedBox(
              width: 10,
            ),
            Expanded(
              child: FormBuilderTextField(
                decoration: InputDecoration(labelText: "Korisnicko ime"),
                name: "korisnikoIme",
              ),
            ),
             SizedBox(
              width: 10,
            ),
            Expanded(
              child: FormBuilderTextField(
                decoration: InputDecoration(labelText: "Password"),
                name: "password",
              ),
            ),
             SizedBox(
              width: 10,
            ),
            Expanded(
              child: FormBuilderTextField(
                decoration: InputDecoration(labelText: "Password potvrda"),
                name: "passwordPotvrda",
              ),
            ),
          ],
        ),
        Row(
          children: [
            Expanded(
                child: FormBuilderDropdown<String>(
              name: 'ulogaId',
              decoration: InputDecoration(
                labelText: 'Uloga',
                suffix: IconButton(
                  icon: const Icon(Icons.close),
                  onPressed: () {
                    _formKey.currentState!.fields['ulogaId']?.reset();
                  },
                ),
                hintText: 'Select Gender',
              ),
              items: ulogaResult?.result
                      .map((item) => DropdownMenuItem(
                            alignment: AlignmentDirectional.center,
                            value: item.id!.toString(),
                            child: Text(item.naziv ?? ""),
                          ))
                      .toList() ??
                  [],
            )),
            SizedBox(
              width: 10,
            ),
          
         
          ],
        ),
        Row(
          children: [
            Expanded(
                child: FormBuilderField(
              name: 'imageId',
              builder: ((field) {
                return InputDecorator(
                  decoration: InputDecoration(
                      label: Text('Odaberite sliku'),
                      errorText: field.errorText),
                  child: ListTile(
                    leading: Icon(Icons.photo),
                    title: Text("Select image"),
                    trailing: Icon(Icons.file_upload),
                    onTap: getImage,
                  ),
                );
              }),
            ))
          ],
        )
      ]),
    );
  }
  
  File? _image;
  String? _base64Image;

  Future getImage()  async {
    var result = await FilePicker.platform.pickFiles(type: FileType.image);

    if(result != null && result.files.single.path != null) {
      _image = File(result.files.single.path!);
      _base64Image = base64Encode(_image!.readAsBytesSync());
    }

  }
}
