
import 'package:eturistickaagencija_admin/providers/base_provider.dart';
import '../models/korisnik.dart';

class KorisnikProvider extends BaseProvider<Korisnik>{
  KorisnikProvider():super("Korisnici");

  @override
  Korisnik fromJson(data) {
    // TODO: implement fromJson
    return Korisnik.fromJson(data);
  }
}