package aes;

import java.io.File;
import java.io.FileOutputStream;
import java.math.BigInteger;
import java.security.KeyFactory;
import java.security.PublicKey;
import java.security.spec.RSAPublicKeySpec;
import java.util.Scanner;

import javax.crypto.Cipher;

public class EncryptedGenerator {

	public void encryptGenerated() throws Exception {
		Scanner s = new Scanner(System.in);
		System.out.println("Digite o texto simples");
		String textoSimples = s.nextLine();
		s.close();
		
		byte[] signed = encrypt(textoSimples);
		
		File file = new File("cifred.txt");
		FileOutputStream in = new FileOutputStream(file) ;  
		in.write(signed);
		in.close();
		System.out.println("Terminou: " + file.getAbsolutePath());
	}
	
	public byte[] encrypt(String message) throws Exception {
        
        RSAPublicKeySpec spec = new RSAPublicKeySpec(
			new BigInteger("16355915802111338823720386765495895652536553347735895992827846151102519313166247893351775254567268987408998913662401359082562005652705089215586421941041992369351402863441151724565464436299353739496470978122996500412278501101090253658037070938691912645934402043234193226346850568048024800962579379887999122323993434707426706917977698593570344083458105302626227923010416610906231653440470861987450657204259880175956930093562446565765295964035506782125104871650123848827441058226359020931626663274003895292508134422565045330172846055355617224683019334671539468151499827534559300948875902651733059065703047869417734677839"),
			new BigInteger("65537")
		);
			
	    KeyFactory kf = KeyFactory.getInstance("RSA");
	    PublicKey key = kf.generatePublic(spec);
        Cipher cipher = Cipher.getInstance("RSA"); 
        cipher.init(Cipher.ENCRYPT_MODE, key);  
        return cipher.doFinal(message.getBytes());  
    }
	
}
