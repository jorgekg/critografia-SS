package controllers;

import java.io.UnsupportedEncodingException;
import java.security.InvalidKeyException;
import java.security.NoSuchAlgorithmException;

import javax.crypto.BadPaddingException;
import javax.crypto.Cipher;
import javax.crypto.IllegalBlockSizeException;
import javax.crypto.NoSuchPaddingException;
import javax.crypto.spec.SecretKeySpec;

public class EncriptController {
	
	private FactoryCriptController cript;
	
	public EncriptController(FactoryCriptController cript) {
		this.cript = cript;
	}
	
	public String encript() throws IllegalBlockSizeException, BadPaddingException, UnsupportedEncodingException, InvalidKeyException, NoSuchAlgorithmException, NoSuchPaddingException {
		SecretKeySpec key = cript.getKey();
        Cipher cipher = cript.getCipher();
		cipher.init(Cipher.ENCRYPT_MODE, key);
		if (cript.getInitialValue() != null && !cript.getInitialValue().isEmpty()) {
			cript.transforTextWithInitialValue();
		}
		return HexController.bytesToHex(cipher.doFinal(cript.getText().getBytes("UTF-8")));
	}
	
}
