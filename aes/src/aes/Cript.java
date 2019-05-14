package aes;

import java.security.KeyFactory;
import java.security.KeyPair;
import java.security.KeyPairGenerator;
import java.security.NoSuchAlgorithmException;
import java.security.PrivateKey;
import java.util.Scanner;

import javax.crypto.Cipher;

public class Cript {

	public static void Main(String[] args) {
		Scanner s = new Scanner(System.in);
		System.out.println("Digite um valor");
		String textoSimples = s.nextLine();
		
		KeyFactory keyFactory = KeyFactory.getInstance("RSA");
		keyFactory.
		
		byte [] signed = encrypt(, textoSimples);     
        System.out.println(new String(signed));
	}
	
	public static byte[] encrypt(PrivateKey privateKey, String message) throws Exception {
        Cipher cipher = Cipher.getInstance("RSA");  
        cipher.init(Cipher.ENCRYPT_MODE, privateKey);  

        return cipher.doFinal(message.getBytes());  
    }
	
	public static KeyPair buildKeyPair() throws NoSuchAlgorithmException {
        final int keySize = 2048;
        KeyPairGenerator keyPairGenerator = KeyPairGenerator.getInstance("RSA");
        keyPairGenerator.initialize(keySize);      
        return keyPairGenerator.;
    }
	
}
