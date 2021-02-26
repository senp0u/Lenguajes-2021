package cr.ac.ucr.teleatlantico.security;

import java.io.IOException;
import java.util.Collections;

import javax.servlet.FilterChain;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.AuthenticationException;
import org.springframework.security.web.authentication.AbstractAuthenticationProcessingFilter;
import org.springframework.security.web.util.matcher.AntPathRequestMatcher;

import cr.ac.ucr.teleatlantico.domain.AccountCredentials;


public class LoginFilter extends AbstractAuthenticationProcessingFilter{

	public LoginFilter(String url, AuthenticationManager authManager) {
		super(new AntPathRequestMatcher(url));
		setAuthenticationManager(authManager);
	}

	@Override
	public Authentication attemptAuthentication(HttpServletRequest request, HttpServletResponse response)
			throws AuthenticationException, IOException, ServletException {
		String email = request.getParameter("email");
		String password = request.getParameter("password");
		
		AccountCredentials accountCredentials = new AccountCredentials(email, password);
		return getAuthenticationManager()
				.authenticate(new UsernamePasswordAuthenticationToken(
					accountCredentials.getEmail(), accountCredentials.getPassword(), 
					Collections.emptyList())
				);
	}
	
	@Override
	protected void successfulAuthentication(
				    HttpServletRequest req,
				    HttpServletResponse res, FilterChain chain,
				    Authentication auth) throws IOException, ServletException {
		AuthenticationService.addToken(res, auth.getName());
	}
}
