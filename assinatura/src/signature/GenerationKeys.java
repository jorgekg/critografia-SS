package signature;

import java.io.FileOutputStream;
import java.security.KeyPair;
import java.security.KeyPairGenerator;
import java.security.NoSuchAlgorithmException;
import java.security.interfaces.RSAPrivateKey;
import java.security.interfaces.RSAPublicKey;

public class GenerationKeys {
	
	public void Key() throws Exception {
        KeyPair keyPair = buildKeyPair();
        RSAPrivateKey privateKey = (RSAPrivateKey) keyPair.getPrivate();
        RSAPublicKey publicKey = (RSAPublicKey) keyPair.getPublic();
        
        try (FileOutputStream fos = new FileOutputStream("./keys/private.key")) {
        	 fos.write(privateKey.getPrivateExponent().toByteArray());
        	 System.out.println("Chave privada gravada em ./keys/private.key");
    	}
        
        try (FileOutputStream fos = new FileOutputStream("./keys/module.key")) {
	       	 fos.write(privateKey.getModulus().toByteArray());
	       	 System.out.println("Modulo gravado em ./keys/module.key");
	   	}
	        
        try (FileOutputStream fos = new FileOutputStream("./keys/public.key")) {
	       	 fos.write(publicKey.getPublicExponent().toByteArray());
	       	System.out.println("Chave public gravada em ./keys/public.key");
	   	}
    }

    public KeyPair buildKeyPair() throws NoSuchAlgorithmException {
        final int keySize = 2048;
        KeyPairGenerator keyPairGenerator = KeyPairGenerator.getInstance("RSA");
        keyPairGenerator.initialize(keySize);      
        return keyPairGenerator.genKeyPair();
    }

}
