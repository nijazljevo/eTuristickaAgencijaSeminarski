import 'dart:convert';
import 'dart:io';

import 'package:eturistickaagencija_admin/providers/grad.dart';
import 'package:file_picker/file_picker.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:http/http.dart' as http;
import 'package:image_picker/image_picker.dart';
import 'package:provider/provider.dart';
import '../models/destinacija.dart';
import '../models/grad.dart';
import '../models/hotel.dart';
import '../models/search_result.dart';
import '../providers/destinacija_provider.dart';
import '../providers/hotel_provider.dart';
import '../widgets/master_screen.dart';

class DestinacijaDetailsScreen extends StatefulWidget {
  Destinacija? destinacija;
  DestinacijaDetailsScreen({Key? key, this.destinacija}) : super(key: key);

  @override
  State<DestinacijaDetailsScreen> createState() => _DestinacijaDetailsScreenState();
}

class _DestinacijaDetailsScreenState extends State<DestinacijaDetailsScreen> {
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};
  late GradProvider _gradProvider;
  late DestinacijaProvider _destinacijaProvider;

  SearchResult<Grad>? gradResult;
  bool isLoading = true;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _initialValue = {
      'naziv': widget.destinacija?.naziv,
      'gradId': widget.destinacija?.gradId?.toString(),
    };

    _gradProvider = context.read<GradProvider>();
    _destinacijaProvider = context.read<DestinacijaProvider>();

    initForm();
  }

  @override
  void didChangeDependencies() {
    // TODO: implement didChangeDependencies
    super.didChangeDependencies();

   
  }

  Future initForm() async {
    gradResult = await _gradProvider.get();
    print(gradResult);


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
                      print(_formKey.currentState?.value['naziv']);

                      var request = new Map.from(_formKey.currentState!.value);

                      request['slika'] = _base64Image;

                      print(request['slika']);
                      
                      try {
                        if (widget.destinacija == null) {
                          await _destinacijaProvider
                              .insert(request);
                        } else {
                          await _destinacijaProvider.update(
                              widget.destinacija!.id!,
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
      title: this.widget.destinacija?.naziv ?? "Destinacija details",
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
                decoration: InputDecoration(labelText: "Naziv"),
                name: "naziv",
              ),
            ),
          ],
        ),
        Row(
          children: [
            Expanded(
                child: FormBuilderDropdown<String>(
              name: 'gradId',
              decoration: InputDecoration(
                labelText: 'Grad',
                suffix: IconButton(
                  icon: const Icon(Icons.close),
                  onPressed: () {
                    _formKey.currentState!.fields['gradId']?.reset();
                  },
                ),
                hintText: 'Select Gender',
              ),
              items: gradResult?.result
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

Future getImage() async {
  var result = await FilePicker.platform.pickFiles(type: FileType.image);

  if (result != null && result.files.isNotEmpty) {
    var filePath = result.files.single.path;
    if (filePath != null) {
      _image = File(filePath);
      _base64Image = base64Encode(_image!.readAsBytesSync());
    }
  }
}


}
