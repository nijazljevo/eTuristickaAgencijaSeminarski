
import 'package:eturistickaagencija_admin/models/drzava.dart';
import 'package:eturistickaagencija_admin/providers/base_provider.dart';



class DrzavaProvider extends BaseProvider<Drzava>{
  DrzavaProvider():super("Drzave");

  @override
  Drzava fromJson(data) {
    // TODO: implement fromJson
    return Drzava.fromJson(data);
  }

}