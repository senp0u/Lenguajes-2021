package cr.ac.ucr.teleatlantico.config;

import java.util.Arrays;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.http.HttpMethod;
import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;
import org.springframework.security.config.annotation.method.configuration.EnableGlobalMethodSecurity;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.config.annotation.web.configuration.WebSecurityConfigurerAdapter;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.security.web.authentication.UsernamePasswordAuthenticationFilter;
import org.springframework.web.cors.CorsConfiguration;
import org.springframework.web.cors.CorsConfigurationSource;
import org.springframework.web.cors.UrlBasedCorsConfigurationSource;

import cr.ac.ucr.teleatlantico.security.AutheticationFilter;
import cr.ac.ucr.teleatlantico.security.CustomUserDetailService;
import cr.ac.ucr.teleatlantico.security.LoginFilter;


@Configuration
@EnableWebSecurity
@EnableGlobalMethodSecurity(securedEnabled = true, proxyTargetClass = true)
public class WebSecurityConfig extends WebSecurityConfigurerAdapter{

	@Autowired
	private CustomUserDetailService userDetailService;
	
	@Override
	protected void configure(HttpSecurity http) throws Exception {
		http.csrf().disable().cors()
				.and().authorizeRequests()
				.antMatchers(HttpMethod.POST, "/login").permitAll()
				.anyRequest().authenticated().and()
				// Filtro para las solicitudes del login
				.addFilterBefore(new LoginFilter("/login", authenticationManager()),
						UsernamePasswordAuthenticationFilter.class)
				// Filtro para otros solicitudes por medio de JWT
				.addFilterBefore(new AutheticationFilter(), UsernamePasswordAuthenticationFilter.class);
	}

	// Cross-Origin Resource Sharing
	// necesario para mandar solicitudes de front end de diferentes origenes
	@Bean
	CorsConfigurationSource corsConfigurationSource() {
		UrlBasedCorsConfigurationSource source = new UrlBasedCorsConfigurationSource();
		CorsConfiguration configuracion = new CorsConfiguration();
		configuracion.setAllowedOrigins(Arrays.asList("*"));
		configuracion.setAllowedMethods(Arrays.asList("*"));
		configuracion.setAllowedHeaders(Arrays.asList("*"));
		configuracion.setAllowCredentials(true);
		configuracion.applyPermitDefaultValues();

		source.registerCorsConfiguration("/**", configuracion);
		return source;
	}

	@Autowired
	public void configureGlobal(AuthenticationManagerBuilder auth) throws Exception {
		auth
			.userDetailsService(userDetailService)
			.passwordEncoder(passwordEncoder());
	}

	// Crea el encriptador de contraseñas
	@Autowired
	@Bean
	public PasswordEncoder passwordEncoder() {
		// El numero 10 representa qué tan fuerte se desea la encriptacion.
		// Se puede en un rango entre 4 y 31.
		return new BCryptPasswordEncoder(10);

	}
}
