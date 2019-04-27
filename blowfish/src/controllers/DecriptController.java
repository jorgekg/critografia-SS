package controllers;

import java.io.UnsupportedEncodingException;
import java.security.InvalidAlgorithmParameterException;
import java.security.InvalidKeyException;
import java.security.NoSuchAlgorithmException;

import javax.crypto.BadPaddingException;
import javax.crypto.Cipher;
import javax.crypto.IllegalBlockSizeException;
import javax.crypto.NoSuchPaddingException;
import javax.crypto.spec.SecretKeySpec;
import javax.xml.bind.DatatypeConverter;

public class DecriptController {
	
	private FactoryCriptController cript;
	
	public DecriptController(FactoryCriptController cript) {
		this.cript = cript;
	}
	
	public String decript() throws UnsupportedEncodingException, NoSuchAlgorithmException, NoSuchPaddingException,
		InvalidKeyException, IllegalBlockSizeException, BadPaddingException, InvalidAlgorithmParameterException {
		SecretKeySpec key = cript.getKey();
        Cipher cipher = cript.getCipher();
        byte[] bytes = DatatypeConverter.parseHexBinary(cript.getText());
		cipher.init(Cipher.DECRYPT_MODE, key);
		byte[] decrypted = cipher.doFinal(bytes);
		return new String(decrypted);
	}

}
