
import 'package:eturistickaagencija_admin/models/kontinent.dart';
import 'package:eturistickaagencija_admin/providers/base_provider.dart';


class KontinentProvider extends BaseProvider<Kontinent>{
  KontinentProvider():super("Kontinenti");

  @override
  Kontinent fromJson(data) {
    // TODO: implement fromJson
    return Kontinent.fromJson(data);
  }

}