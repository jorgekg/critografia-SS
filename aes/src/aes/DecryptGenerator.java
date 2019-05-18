package aes;

import java.math.BigInteger;
import java.security.KeyFactory;
import java.security.PublicKey;
import java.security.spec.RSAPublicKeySpec;
import java.util.Scanner;

import javax.crypto.Cipher;

public class DecryptGenerator {
	
	public void decryptGenerated() throws Exception {
		Scanner s = new Scanner(System.in);
		System.out.println("Digite o texto crifrado");
		String textoCifrado = s.nextLine();
		s.close();
		
		byte[] signed = decrypt(textoCifrado);     
        System.out.println(new String(signed));
	}
	
	public byte[] decrypt(String message) throws Exception {
		RSAPublicKeySpec spec = new RSAPublicKeySpec(
			new BigInteger("24339457823852923454378924854195176828708210422122427957966825813576590128876077580738826479821192703878378129726784363529988582112521351714881162984818501467174268081669635113038786690159746439895618400893561931335127568274707381079274161517372374626070330745855219207630614214242273447214178020209059453260782183478281382663783677113323777022895905859291280590418607936715792581897560427940187669673926559277062426558777420993485884235801357865794566494118779291863847244334833646684000359676488513696763178766431392733831201125406214847131282055467130391664570109965119305852803748467566779197663030167764296189553".getBytes()),
			new BigInteger("65537".getBytes())
		);
			
	    KeyFactory kf = KeyFactory.getInstance("RSA");
	    PublicKey key = kf.generatePublic(spec);
        Cipher cipher = Cipher.getInstance("RSA");  
        cipher.init(Cipher.DECRYPT_MODE, key);  
        return cipher.doFinal(message.getBytes());  
    }
}
