package signature;

import java.math.BigInteger;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.security.KeyFactory;
import java.security.PublicKey;
import java.security.spec.RSAPublicKeySpec;

public class ValidateSignature {

	public void validate() throws Exception {
		
		byte[] publicKey = Files.readAllBytes(Paths.get("./keys/public.key"));
		byte[] module = Files.readAllBytes(Paths.get("./keys/module.key"));
		System.out.println("Recuperado a chave de ./keys/public.key");
		RSAPublicKeySpec spec = new RSAPublicKeySpec(
				new BigInteger(module),
				new BigInteger(publicKey)
			);
		byte[] simpleText = Files.readAllBytes(Paths.get("./archive/simpleText.txt"));
		System.out.println("Recuperado o texto simples de ./archive/simpleText.txt");
		
		byte[] signatureKey = Files.readAllBytes(Paths.get("./signature/sign.sign"));
		System.out.println("Recuperado a assinatura de ./signature/sign.sign");
		
		KeyFactory kf = KeyFactory.getInstance("RSA");
	    PublicKey key = kf.generatePublic(spec);
		
		java.security.Signature signature = java.security.Signature.getInstance("SHA1withRSA");
		signature.initVerify(key);
		signature.update(simpleText);
		
		if (signature.verify(signatureKey)) {
		System.out.println("Arquivo recebido é válido");
		} else {
		System.err.println("Arquivo recebido não é válido");
		}
	}
	
}
