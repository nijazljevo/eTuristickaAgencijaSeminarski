import 'package:eturistickaagencija_admin/providers/agencija_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';

import '../models/agencija.dart';
import '../providers/kontinent_provider.dart';
import '../widgets/master_screen.dart';

class AgencijaDetailsScreen extends StatefulWidget {
  final Agencija? agencija;

  AgencijaDetailsScreen({Key? key, this.agencija}) : super(key: key);

  @override
  State<AgencijaDetailsScreen> createState() => _AgencijaDetailsScreenState();
}

class _AgencijaDetailsScreenState extends State<AgencijaDetailsScreen> {
  final _formKey = GlobalKey<FormBuilderState>();
  late AgencijaProvider _agencijaProvider;

  bool isLoading = true;

  @override
  void initState() {
    super.initState();
    _agencijaProvider = context.read<AgencijaProvider>();
    initForm();
  }

  Future<void> initForm() async {
    if (widget.agencija != null) {
      _formKey.currentState?.reset();
      _formKey.currentState?.fields['adresa']?.didChange(widget.agencija!.adresa);
      _formKey.currentState?.fields['email']?.didChange(widget.agencija!.email);
      _formKey.currentState?.fields['telefon']?.didChange(widget.agencija!.telefon);
    } else {
      _formKey.currentState?.reset();
      _formKey.currentState?.fields['adresa']?.didChange('');
      _formKey.currentState?.fields['email']?.didChange('');
      _formKey.currentState?.fields['telefon']?.didChange('');
    }

    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
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
                    if (_formKey.currentState?.saveAndValidate() ?? false) {
                      try {
                        if (widget.agencija == null) {
                          await _agencijaProvider.insert(_formKey.currentState?.value);
                        } else {
                          await _agencijaProvider.update(widget.agencija!.id!, _formKey.currentState?.value);
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
                                child: Text("OK"),
                              )
                            ],
                          ),
                        );
                      }
                    }
                  },
                  child: Text('Sacuvaj'),
                ),
              )
            ],
          )
        ],
      ),
      title: widget.agencija?.email ?? 'Agencija details',
    );
  }

  FormBuilder _buildForm() {
    return FormBuilder(
      key: _formKey,
      initialValue: {
        'adresa': widget.agencija?.adresa ?? '',
        'email': widget.agencija?.email ?? '',
        'telefon': widget.agencija?.telefon ?? '',
      },
      child: Column(
        children: [
          FormBuilderTextField(
            decoration: InputDecoration(
              labelText: "Adresa",
            ),
            name: "adresa",
            validator: FormBuilderValidators.required(context),
          ),
          FormBuilderTextField(
            decoration: InputDecoration(
              labelText: "Email",
            ),
            name: "email",
            validator: FormBuilderValidators.required(context),
          ),
          FormBuilderTextField(
            decoration: InputDecoration(
              labelText: "Telefon",
            ),
            name: "telefon",
            validator: FormBuilderValidators.required(context),
          ),
        ],
      ),
    );
  }
}
