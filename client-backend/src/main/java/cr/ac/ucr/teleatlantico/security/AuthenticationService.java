package cr.ac.ucr.teleatlantico.security;

import java.util.Collections;
import java.util.Date;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.Authentication;

import io.jsonwebtoken.Jwts;
import io.jsonwebtoken.SignatureAlgorithm;

public class AuthenticationService {

	static final long EXPIRATION_TIME = 432_000_00; // 1/2 dia en milisegundos
	static final String SIGNIN_KEY = "SecretKey"; // El algoritmo especifica una llave de incio de sesion
												// the JWT
	static final String PREFIX = "Bearer";

	static public void addToken(HttpServletResponse res, String nombreUsuario) {
		String JwtToken = Jwts.builder().setSubject(nombreUsuario)
				.setExpiration(new Date(System.currentTimeMillis() + EXPIRATION_TIME))
				.signWith(SignatureAlgorithm.HS512, SIGNIN_KEY).compact(); // La llave es codificada con sha512
		res.addHeader("Authorization", PREFIX + " " + JwtToken);
		res.addHeader("Access-Control-Expose-Headers", "Authorization");
	}

	static public Authentication getAuthentication(HttpServletRequest request) {
		String token = request.getHeader("Authorization");
		if (token != null) {
			String client = Jwts.parser().setSigningKey(SIGNIN_KEY).parseClaimsJws(token.replace(PREFIX, "")).getBody()
					.getSubject();
			if (client != null)
				return new UsernamePasswordAuthenticationToken(client, null, Collections.emptyList());
		}
		return null;
	}
}
