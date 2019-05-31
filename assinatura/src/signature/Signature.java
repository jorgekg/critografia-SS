package signature;

import java.io.FileOutputStream;
import java.io.IOException;
import java.math.BigInteger;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.security.InvalidKeyException;
import java.security.KeyFactory;
import java.security.NoSuchAlgorithmException;
import java.security.PrivateKey;
import java.security.SignatureException;
import java.security.spec.InvalidKeySpecException;
import java.security.spec.RSAPrivateKeySpec;

public class Signature {

	public void sign() throws IOException, SignatureException, InvalidKeyException, NoSuchAlgorithmException, InvalidKeySpecException {
		byte[] privateKey = Files.readAllBytes(Paths.get("./keys/private.key"));
		byte[] module = Files.readAllBytes(Paths.get("./keys/module.key"));
		System.out.println("Recuperado a chave de ./keys/private.key");
		RSAPrivateKeySpec privateKeyRSA = new RSAPrivateKeySpec(
				new BigInteger(module),
				new BigInteger(privateKey)
			);
		byte[] simpleText = Files.readAllBytes(Paths.get("./archive/simpleText.txt"));
		System.out.println("Recuperado o texto simples de ./archive/simpleText.txt");
		
		KeyFactory kf = KeyFactory.getInstance("RSA");
	    PrivateKey key = kf.generatePrivate(privateKeyRSA);
		
		java.security.Signature signature = java.security.Signature.getInstance("SHA1WithRSA");
		signature.initSign(key);
		signature.update(simpleText);
		
		byte[] sign = signature.sign();
		
		try (FileOutputStream fos = new FileOutputStream("./signature/sign.sign")) {
	       	 fos.write(sign);
	       	 System.out.println("assinatura gerada em ./signature/sign.sign");
		}
		
	}
	
}
